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
  public sealed class BookRepository : RepositoryBase<IBookEntity, BookEntity>, IBookRepository
  {
    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Infrastructure.Repository.BookRepository"/> class.</summary>
    /// <param name="dbContext">An object that represents a session with the database and can be used to query and save instances of your entities.</param>
    public BookRepository(DbContext dbContext) : base(dbContext) {}

    /// <summary>Gets a book.</summary>
    /// <param name="bookIdentity">An object that represents a book identity.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="AspNetPatchSample.Domain.Entity.IBookEntity"/>. The result can be null.</returns>
    public async Task<IBookEntity?> GetAsync(IBookIdentity bookIdentity, CancellationToken cancellationToken)
      => await DbContext.Set<BookEntity>()
                        .AsNoTracking()
                        .Where(entity => entity.BookId == bookIdentity.BookId)
                        .FirstOrDefaultAsync(cancellationToken);
  }
}
