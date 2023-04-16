// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.WebApi.Dtos
{
  using System.ComponentModel.DataAnnotations;

  using Microsoft.AspNetCore.Mvc;

  using AspNetPatchSample.Domain.Entity;

  /// <summary>Represents data to update a book parially.</summary>
  public sealed class PatchBookRequestDto : IBookEntity, IPatchable
  {
    /// <summary>Initalizes a new instance of the <see cref="AspNetPatchSample.WebApi.Dtos.PatchBookRequestDto"/> class.</summary>
    public PatchBookRequestDto()
    {
      Name        = string.Empty;
      Author      = string.Empty;
      Description = string.Empty;
      Properties  = Array.Empty<string>();
    }

    /// <summary>Gets an object that represents an ID of a book.</summary>
    [FromRoute]
    public Guid BookId { get; set; }

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

    /// <summary>Gets an object that represents a collection of properties to update.</summary>
    public string[] Properties { get; set; }
  }
}
