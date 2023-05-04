// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Book.Data
{
  using System.Threading;
  using System.Threading.Tasks;

  using Microsoft.EntityFrameworkCore;

  using AspNetPatchSample;
  using AspNetPatchSample.Book;
  using AspNetPatchSample.Data;
  using AspNetPatchSample.Data.Book;
  using System.Collections.Generic;

  /// <summary>Provides a simple API to store instances of the <see cref="AspNetPatchSample.Book.IBookEntity"/>.</summary>
  public sealed class BookRepository : RepositoryBase<IBookEntity, BookEntity>, IBookRepository
  {
    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Book.Data.BookRepository"/> class.</summary>
    /// <param name="dbContext">An object that represents a session with the database and can be used to query and save instances of your entities.</param>
    public BookRepository(DbContext dbContext) : base(dbContext) { }

    public override async Task<IBookEntity?> GetAsync(IIdentity identity, CancellationToken cancellationToken)
      => await DbContext.Set<BookEntity>()
                        .AsNoTracking()
                        .Include(entity => entity.Authors)
                        .Where(entity => entity.Id == identity.Id)
                        .SingleOrDefaultAsync(cancellationToken);

    public override async Task<IBookEntity> AddAsync(IBookEntity entity, CancellationToken cancellationToken)
    {
      var dbBookEntity = await base.AddAsync(entity, cancellationToken);
      await AddBookAuthors(entity, cancellationToken);

      return dbBookEntity;
    }

    public override async Task UpdateAsync(IBookEntity bookEntity, IEnumerable<string> properties, CancellationToken cancellationToken)
    {
      if (properties.Contains(nameof(IBookEntity.Authors)))
      {
        await DbContext.Set<BookAuthorEntity>()
                       .Where(entity => entity.BookId == bookEntity.Id)
                       .ExecuteDeleteAsync(cancellationToken);

        await AddBookAuthors(bookEntity, cancellationToken);
      }

      await base.UpdateAsync(bookEntity, properties, cancellationToken);
    }

    private Task AddBookAuthors(IBookEntity bookEntity, CancellationToken cancellationToken)
    {
      var bookAuthorEntities =
        bookEntity.Authors.Select(entity => new BookAuthorEntity(bookEntity.Id, entity.Id))
                          .ToArray();

      DbContext.AddRange(bookAuthorEntities);

      return DbContext.SaveChangesAsync(cancellationToken);
    }
  }
}
