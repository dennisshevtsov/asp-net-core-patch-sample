// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Infrastructure.Author
{
  using Microsoft.EntityFrameworkCore;
  using AspNetPatchSample.Author;
  using AspNetPatchSample.Infrastructure;

  /// <summary>Provides a simple API to store instances of the <see cref="AspNetPatchSample.Domain.Author.IAuthorEntity"/>.</summary>
  public sealed class AuthorRepository : RepositoryBase<IAuthorEntity, AuthorEntity>, IAuthorRepository
  {
    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Infrastructure.Author.AuthorRepository"/> class.</summary>
    /// <param name="dbContext">An object that represents a session with the database and can be used to query and save instances of your entities.</param>
    public AuthorRepository(DbContext dbContext) : base(dbContext) { }

    /// <summary>Gets an author by an ID of this entity.</summary>
    /// <param name="identity">An object that represents an author identity.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="IAuthorEntity"/>.</returns>
    public async Task<IAuthorEntity?> GetAsync(IAuthorIdentity identity, CancellationToken cancellationToken)
      => await DbContext.Set<AuthorEntity>()
                        .AsNoTracking()
                        .Where(entity => entity.AuthorId == identity.AuthorId)
                        .FirstOrDefaultAsync(cancellationToken);
  }
}
