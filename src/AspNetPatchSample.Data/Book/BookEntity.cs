// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Book.Data
{
  using AspNetPatchSample.Data;

  /// <summary>Represents a book entity.</summary>
  public sealed class BookEntity : EntityBase, IBookEntity
  {
    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Book.Data.BookEntity"/> class.</summary>
    public BookEntity()
    {
      Title        = string.Empty;
      Author      = string.Empty;
      Description = string.Empty;
    }

    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Book.Data.BookEntity"/> class.</summary>
    /// <param name="orderEntity">An object that represents a book entity.</param>
    public BookEntity(IBookEntity orderEntity)
    {
      Title        = orderEntity.Title;
      Author      = orderEntity.Author;
      Description = orderEntity.Description;
      Pages       = orderEntity.Pages;
      BookId      = orderEntity.BookId;
    }

    /// <summary>Gets an object that represents an ID of a book.</summary>
    public Guid BookId { get => Id; set => Id = value; }

    /// <summary>Gets an object that represents a title of a book.</summary>
    public string Title { get; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    public string Author { get; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    public string Description { get; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    public int Pages { get; }
  }
}
