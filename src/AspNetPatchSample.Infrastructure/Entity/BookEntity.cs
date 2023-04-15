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
      Name = string.Empty;
    }

    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Infrastructure.Entity.BookEntity"/> class.</summary>
    /// <param name="bookData">An object that represents book data.</param>
    public BookEntity(IBookData bookData)
    {
      Name = bookData.Name;
      Description = bookData.Description;
    }

    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Infrastructure.Entity.BookEntity"/> class.</summary>
    /// <param name="orderData">An object that represents an order entity.</param>
    public BookEntity(IBookEntity orderEntity)
    {
      BookId = orderEntity.BookId;
      Name = orderEntity.Name;
      Description = orderEntity.Description;
    }

    /// <summary>Gets an object that represents an ID of a book.</summary>
    public Guid BookId { get; set; }

    /// <summary>Gets an object that represents a name of a book.</summary>
    public string Name { get; set; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    public string? Description { get; set; }
  }
}
