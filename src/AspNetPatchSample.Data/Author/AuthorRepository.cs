// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Author.Data
{
  using Microsoft.EntityFrameworkCore;

  using AspNetPatchSample.Author;
  using AspNetPatchSample.Data;

  /// <summary>Provides a simple API to store instances of the <see cref="AspNetPatchSample.Author.IAuthorEntity"/>.</summary>
  public sealed class AuthorRepository : RepositoryBase<IAuthorEntity, AuthorEntity>, IAuthorRepository
  {
    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Author.Data.AuthorRepository"/> class.</summary>
    /// <param name="dbContext">An object that represents a session with the database and can be used to query and save instances of your entities.</param>
    public AuthorRepository(DbContext dbContext) : base(dbContext) { }
  }
}
