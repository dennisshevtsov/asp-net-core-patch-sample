// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Infrastructure.Repository
{
  using Microsoft.EntityFrameworkCore;

  using AspNetPatchSample.Domain.Entity;
  using AspNetPatchSample.Domain.Repository;
  using AspNetPatchSample.Infrastructure.Entity;

  /// <summary>Provides a simple API to store instances of the <see cref="AspNetPatchSample.Domain.Entity.IBookEntity"/>.</summary>
  public sealed class BookRepository : IBookRepository
  {
    private readonly DbContext _dbContext;

    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Infrastructure.Repository.BookRepository"/> class.</summary>
    /// <param name="dbContext">An object that represents a session with the database and can be used to query and save instances of your entities.</param>
    public BookRepository(DbContext dbContext)
    {
      _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    /// <summary>Gets a book.</summary>
    /// <param name="bookIdentity">An object that represents a book identity.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="AspNetPatchSample.Domain.Entity.IBookEntity"/>. The result can be null.</returns>
    public async Task<IBookEntity?> GetBookAsync(IBookIdentity bookIdentity, CancellationToken cancellationToken)
      => await _dbContext.Set<BookEntity>()
                         .AsNoTracking()
                         .Where(entity => entity.BookId == bookIdentity.BookId)
                         .FirstOrDefaultAsync(cancellationToken);

    /// <summary>Adds a book.</summary>
    /// <param name="bookData">An object that reprents book data.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="AspNetPatchSample.Domain.Entity.IBookEntity"/>.</returns>
    public async Task<IBookEntity> AddBookAsync(IBookData bookData, CancellationToken cancellationToken)
    {
      var dbOrderEntity = new BookEntity(bookData);
      var dbOrderEntityEntry = _dbContext.Entry(dbOrderEntity);

      dbOrderEntityEntry.State = EntityState.Added;
      await _dbContext.SaveChangesAsync(cancellationToken);
      dbOrderEntityEntry.State = EntityState.Detached;

      return dbOrderEntity;
    }

    /// <summary>Updates a book.</summary>
    /// <param name="bookEntity">An object that represents a book entity.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public async Task UpdateBookAsync(IBookEntity bookEntity, CancellationToken cancellationToken)
    {
      var dbOrderEntity = new BookEntity(bookEntity);
      var dbOrderEntityEntry = _dbContext.Entry(dbOrderEntity);

      dbOrderEntityEntry.State = EntityState.Modified;
      await _dbContext.SaveChangesAsync(cancellationToken);
      dbOrderEntityEntry.State = EntityState.Detached;
    }

    /// <summary>Updates a book.</summary>
    /// <param name="bookEntity">An object that represents a book entity.</param>
    /// <param name="patchable">An object that represents an entity that can be updated partially.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public async Task UpdateBookAsync(IBookEntity bookEntity, IPatchable patchable, CancellationToken cancellationToken)
    {
      var dbOrderEntity = new BookEntity(bookEntity);
      var dbOrderEntityEntry = _dbContext.Entry(dbOrderEntity);

      for (int i = 0; i < patchable.Properties.Length; i++)
      {
        dbOrderEntityEntry.Property(patchable.Properties[i]).IsModified = true;
      }

      await _dbContext.SaveChangesAsync(cancellationToken);
      dbOrderEntityEntry.State = EntityState.Detached;
    }
  }
}
