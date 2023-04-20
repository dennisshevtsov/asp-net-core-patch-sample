// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.WebApi.Dtos
{
  using System.ComponentModel.DataAnnotations;

  using AspNetPatchSample.Book;

  /// <summary>Represents data to add a book.</summary>
  public sealed class PostBookRequestDto : IBookData
  {
    /// <summary>Initalizes a new instance of the <see cref="AspNetPatchSample.WebApi.Dtos.PostBookRequestDto"/> class.</summary>
    public PostBookRequestDto()
    {
      Name        = string.Empty;
      Author      = string.Empty;
      Description = string.Empty;
    }

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
  }
}
