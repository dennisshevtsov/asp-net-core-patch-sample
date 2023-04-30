// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Book.Web
{
  /// <summary>Represents a book entity.</summary>
  public sealed class GetBookResponseDto : IBookEntity
  {
    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Web.Dtos.GetBookResponseDto"/> class.</summary>
    /// <param name="orderEntity">An object that represents a book entity.</param>
    public GetBookResponseDto(IBookEntity orderEntity)
    {
      BookId      = orderEntity.BookId;
      Title       = orderEntity.Title;
      Author      = orderEntity.Author;
      Description = orderEntity.Description;
      Pages       = orderEntity.Pages;
    }

    /// <summary>Gets an object that represents an ID of a book.</summary>
    public Guid BookId { get; }

    /// <summary>Gets an object that represents a title of a book.</summary>
    public string Title { get; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    public string Author { get; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    public string Description { get; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    public int Pages { get; }

    /// <summary>Converts this object to an instance of the <see cref="System.Guid"/>.</summary>
    /// <returns>An object that represents a Globally Unique Identifier.</returns>
    public Guid ToGuid() => BookId;
  }
}
