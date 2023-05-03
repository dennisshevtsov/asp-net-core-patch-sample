// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Book.Data
{
  using Microsoft.EntityFrameworkCore;

  using AspNetPatchSample.Book;
  using AspNetPatchSample.Data;
  using System.Threading.Tasks;
  using AspNetPatchSample;
  using System.Threading;
  using AspNetPatchSample.Author.Data;

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
  }
}
