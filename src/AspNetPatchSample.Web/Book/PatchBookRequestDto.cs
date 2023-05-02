// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Book.Web
{
  using System.Text.Json.Serialization;

  using AspNetPatchSample.Web;

  /// <summary>Represents data to update a book parially.</summary>
  public sealed class PatchBookRequestDto : PatchRequestDtoBase, IBookEntity
  {
    /// <summary>Initalizes a new instance of the <see cref="AspNetPatchSample.Web.Dtos.PatchBookRequestDto"/> class.</summary>
    public PatchBookRequestDto() : base()
    {
      Title       = string.Empty;
      Author      = string.Empty;
      Description = string.Empty;
      Properties  = Array.Empty<string>();
    }

    /// <summary>Gets/sets an object that represents an ID of a book.</summary>
    [JsonPropertyName("bookId")]
    public Guid Id { get; set; }

    /// <summary>Gets an object that represents a title of a book.</summary>
    public string Title { get; set; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    public string Author { get; set; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    public string Description { get; set; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    public int Pages { get; set; }
  }
}
