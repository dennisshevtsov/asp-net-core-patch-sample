// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Book.Web
{
  /// <summary>Represents a condition to query a book.</summary>
  public sealed class GetBookRequestDto : BookRequestDtoBase, IBookIdentity
  {
    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Web.Dtos.GetBookRequestDto"/> class.</summary>
    public GetBookRequestDto() : base() { }

    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Web.Dtos.GetBookRequestDto"/> class.</summary>
    /// <param name="bookIdentity">An object that represents an identity of a book.</param>
    public GetBookRequestDto(IBookIdentity bookIdentity) : this()
    {
      Id = bookIdentity.Id;
    }
  }
}
