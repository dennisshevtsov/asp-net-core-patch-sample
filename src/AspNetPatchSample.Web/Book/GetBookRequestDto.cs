// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Book.Web
{
  using AspNetPatchSample.Web;

  /// <summary>Represents a condition to query a book.</summary>
  public sealed class GetBookRequestDto : RequestDtoBase, IBookIdentity
  {
    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Web.Dtos.GetBookRequestDto"/> class.</summary>
    public GetBookRequestDto() : base() { }

    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Web.Dtos.GetBookRequestDto"/> class.</summary>
    /// <param name="bookIdentity">An object that represents an identity of a book.</param>
    public GetBookRequestDto(IBookIdentity bookIdentity) : this()
    {
      BookId = bookIdentity.BookId;
    }

    /// <summary>Gets an object that represents an ID of a book.</summary>
    public Guid BookId { get; set; }

    /// <summary>Converts this object to an instance of the <see cref="System.Guid"/>.</summary>
    /// <returns>An object that represents a Globally Unique Identifier.</returns>
    public Guid ToGuid() => BookId;
  }
}
