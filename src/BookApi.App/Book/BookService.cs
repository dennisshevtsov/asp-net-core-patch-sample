// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using BookApi.App;

namespace BookApi.Book.App;

/// <summary>Represents a simple API to operate instances of the <see cref="BookApi.Book.IBookEntity"/>.</summary>
public sealed class BookService : ServiceBase<BookEntity, IBookEntity, IBookIdentity>, IBookService
{
  /// <summary>Initializes a new instance of the <see cref="BookApi.Book.App.BookService"/> class.</summary>
  /// <param name="bookRepository">An object that provides a simple API to store instances of the <see cref="BookApi.Book.IBookEntity"/>.</param>
  public BookService(IBookRepository bookRepository) : base(bookRepository) { }
}
