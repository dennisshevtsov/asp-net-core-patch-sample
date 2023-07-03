// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Microsoft.EntityFrameworkCore;

using BookApi.Data;

namespace BookApi.Book.Data;

/// <summary>Provides a simple API to store instances of the <see cref="BookApi.Book.IBookEntity"/>.</summary>
public sealed class BookRepository : RepositoryBase<BookEntity, IBookEntity, IBookIdentity>, IBookRepository
{
  /// <summary>Initializes a new instance of the <see cref="BookApi.Book.Data.BookRepository"/> class.</summary>
  /// <param name="dbContext">An object that represents a session with the database and can be used to query and save instances of your entities.</param>
  public BookRepository(DbContext dbContext) : base(dbContext) { }
}
