// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.WebApi.Dtos
{
  using System.ComponentModel.DataAnnotations;

  using Microsoft.AspNetCore.Mvc;

  using AspNetPatchSample.Domain.Entity;

  /// <summary>Represents data to update a book.</summary>
  public sealed class PutBookRequestDto : IBookEntity
  {
    /// <summary>Initalizes a new instance of the <see cref="AspNetPatchSample.WebApi.Dtos.PutBookRequestDto"/> class.</summary>
    public PutBookRequestDto()
    {
      Name        = string.Empty;
      Author      = string.Empty;
      Description = string.Empty;
    }

    /// <summary>Gets an object that represents an ID of a book.</summary>
    [FromRoute]
    public Guid BookId { get; }

    /// <summary>Gets an object that represents a name of a book.</summary>
    [Required]
    [FromBody]
    public string Name { get; set; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    [Required]
    [FromBody]
    public string Author { get; set; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    [Required]
    [FromBody]
    public string Description { get; set; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    [Required]
    [FromBody]
    public int Pages { get; set; }
  }
}
