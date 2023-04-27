// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Book.Web
{
  using System.ComponentModel.DataAnnotations;
  using System.Text.Json.Serialization;

  /// <summary>Represents data to add a book.</summary>
  public sealed class PostBookRequestDto : IBookEntity
  {
    /// <summary>Initalizes a new instance of the <see cref="AspNetPatchSample.Web.Dtos.PostBookRequestDto"/> class.</summary>
    public PostBookRequestDto()
    {
      Name        = string.Empty;
      Author      = string.Empty;
      Description = string.Empty;
    }

    /// <summary>Gets an object that represents an ID of a book.</summary>
    [JsonIgnore]
    public Guid BookId => Guid.Empty;

    /// <summary>Gets an object that represents a name of a book.</summary>
    [Required]
    public string Name { get; set; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    [Required]
    public string Author { get; set; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    [Required]
    public string Description { get; set; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    [Required]
    public int Pages { get; set; }

    /// <summary>Converts this object to an instance of the <see cref="System.Guid"/>.</summary>
    /// <returns>An object that represents a Globally Unique Identifier.</returns>
    public Guid ToGuid() => BookId;
  }
}
