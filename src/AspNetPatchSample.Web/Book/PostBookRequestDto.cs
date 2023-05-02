﻿// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Book.Web
{
  using System.ComponentModel.DataAnnotations;
  using System.Text.Json.Serialization;

  using AspNetPatchSample.Web;

  /// <summary>Represents data to add a book.</summary>
  public sealed class PostBookRequestDto : RequestDtoBase, IBookEntity
  {
    /// <summary>Initalizes a new instance of the <see cref="AspNetPatchSample.Web.Dtos.PostBookRequestDto"/> class.</summary>
    public PostBookRequestDto() : base()
    {
      Title       = string.Empty;
      Author      = string.Empty;
      Description = string.Empty;
    }

    /// <summary>Gets an object that represents an ID of a book.</summary>
    [JsonIgnore]
    public Guid Id => Guid.Empty;

    /// <summary>Gets an object that represents a title of a book.</summary>
    [Required]
    public string Title { get; set; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    [Required]
    public string Author { get; set; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    [Required]
    public string Description { get; set; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    [Required]
    public int Pages { get; set; }
  }
}
