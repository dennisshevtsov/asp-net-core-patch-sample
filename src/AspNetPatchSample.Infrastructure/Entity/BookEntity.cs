// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Infrastructure.Entity
{
  using AspNetPatchSample.Domain.Entity;

  /// <summary>Represents a book entity.</summary>
  public sealed class BookEntity : IBookEntity
  {
    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Infrastructure.Entity.BookEntity"/> class.</summary>
    public BookEntity()
    {
      Name        = string.Empty;
      Author      = string.Empty;
      Description = string.Empty;
    }

    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Infrastructure.Entity.BookEntity"/> class.</summary>
    /// <param name="bookData">An object that represents book data.</param>
    public BookEntity(IBookData bookData)
    {
      Name        = bookData.Name;
      Author      = bookData.Author;
      Description = bookData.Description;
      Pages       = bookData.Pages;
    }

    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Infrastructure.Entity.BookEntity"/> class.</summary>
    /// <param name="orderEntity">An object that represents a book entity.</param>
    public BookEntity(IBookEntity orderEntity)
    {
      BookId      = orderEntity.BookId;
      Name        = orderEntity.Name;
      Author      = orderEntity.Author;
      Description = orderEntity.Description;
      Pages       = orderEntity.Pages;
    }

    /// <summary>Gets an object that represents an ID of a book.</summary>
    public Guid BookId { get; }

    /// <summary>Gets an object that represents a name of a book.</summary>
    public string Name { get; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    public string Author { get; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    public string Description { get; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    public int Pages { get; }
  }
}
