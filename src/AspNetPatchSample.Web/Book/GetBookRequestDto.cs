// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Book.Web
{
  using System.Text.Json.Serialization;

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
      Id = bookIdentity.Id;
    }

    /// <summary>Gets/sets an object that represents an ID of a book.</summary>
    [JsonPropertyName("bookId")]
    public Guid Id { get; set; }
  }
}
