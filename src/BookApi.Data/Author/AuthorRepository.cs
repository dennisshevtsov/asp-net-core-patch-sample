// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Microsoft.EntityFrameworkCore;

using BookApi.Data;

namespace BookApi.Author.Data;

/// <summary>Provides a simple API to store instances of the <see cref="BookApi.Author.IAuthorEntity"/>.</summary>
public sealed class AuthorRepository : RepositoryBase<AuthorEntity, IAuthorEntity, IAuthorIdentity>, IAuthorRepository
{
  /// <summary>Initializes a new instance of the <see cref="BookApi.Author.Data.AuthorRepository"/> class.</summary>
  /// <param name="dbContext">An object that represents a session with the database and can be used to query and save instances of your entities.</param>
  public AuthorRepository(DbContext dbContext) : base(dbContext) { }
}
