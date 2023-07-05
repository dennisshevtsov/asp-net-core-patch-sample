// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

using BookApi.Web;

namespace BookApi.Author.Web;

/// <summary>Represents the PATCH author request data.</summary>
public sealed class PatchAuthorRequestDto : IRequestDto, IPatchable, IAuthorEntity
{
  /// <summary>Initializes a new instance of the <see cref="BookApi.Author.Web.PatchAuthorRequestDto"/> class.</summary>
  public PatchAuthorRequestDto()
  {
    Name       = string.Empty;
    Properties = Array.Empty<string>();
  }

  /// <summary>Gets an objecct that represents an ID of an author.</summary>
  public Guid AuthorId { get; set; }

  /// <summary>Gets/sets an object that represents a name of an author.</summary>
  [Required]
  [MaxLength(255)]
  public string Name { get; set; }

  /// <summary>Gets an object that represents a collection of properties to update.</summary>
  [JsonIgnore]
  public IEnumerable<string> Properties { get; set; }
}
