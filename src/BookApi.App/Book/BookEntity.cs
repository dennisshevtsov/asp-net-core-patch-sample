// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using BookApi.App;
using BookApi.Author;

namespace BookApi.Book.App;

/// <summary>Represents a book entity.</summary>
public sealed class BookEntity : EntityBase, IBookEntity
{
  /// <summary>Initializes a new instance of the <see cref="BookApi.Book.App.BookEntity"/> class.</summary>
  public BookEntity()
  {
    Title       = string.Empty;
    Description = string.Empty;
    Authors     = Array.Empty<IAuthorEntity>();
  }

  /// <summary>Initializes a new instance of the <see cref="BookApi.Book.App.BookEntity"/> class.</summary>
  /// <param name="bookIdentity">An object that represents an identity of a book.</param>
  public BookEntity(IBookIdentity bookIdentity) : this()
  {
    BookId = bookIdentity.BookId;
  }

  /// <summary>Initializes a new instance of the <see cref="BookApi.Book.App.BookEntity"/> class.</summary>
  /// <param name="bookEntity">An object that represents a book entity.</param>
  public BookEntity(IBookEntity bookEntity) : this((IBookIdentity) bookEntity)
  {
    BookId      = bookEntity.BookId;
    Title       = bookEntity.Title;
    Description = bookEntity.Description;
    Pages       = bookEntity.Pages;
    Authors     = bookEntity.Authors;
  }

  /// <summary>Gets an object that represents an ID of a book.</summary>
  public Guid BookId { get; }

  /// <summary>Gets/sets an object that represents a title of a book.</summary>
  public string Title { get; private set; }

  /// <summary>Gets/sets an object that represents a description of a book.</summary>
  public string Description { get; private set; }

  /// <summary>Gets/sets an object that represents a description of a book.</summary>
  public int Pages { get; private set; }

  /// <summary>Gets an object that represents a collection of authors of this book.</summary>
  public IEnumerable<IAuthorEntity> Authors { get; private set; }

  /// <summary>Gets an object that represents a collection of related entities.</summary>
  public override IEnumerable<string> Relations()
  {
    yield return nameof(IBookEntity.Authors);
  }
}
