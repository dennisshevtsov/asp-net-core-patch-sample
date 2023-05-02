// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Book.Web
{
  using System.Text.Json.Serialization;

  using AspNetPatchSample.Web;

  /// <summary>Represents data to delete a book.</summary>
  public sealed class DeleteBookRequestDto : RequestDtoBase, IBookIdentity
  {
    /// <summary>Gets/sets an object that represents an ID of a book.</summary>
    [JsonPropertyName("bookId")]
    public Guid Id { get; set; }
  }
}
