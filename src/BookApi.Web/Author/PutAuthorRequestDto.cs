// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace BookApi.Author.Web
{
  using BookApi.Web;
  using System.ComponentModel.DataAnnotations;

  /// <summary>Represents the PUT author request data.</summary>
  public sealed class PutAuthorRequestDto : IRequestDto, IAuthorEntity
  {
    /// <summary>Initializes a new instance of the <see cref="BookApi.Author.Web.PutAuthorRequestDto"/> class.</summary>
    public PutAuthorRequestDto()
    {
      Name = string.Empty;
    }

    /// <summary>Gets an objecct that represents an ID of an author.</summary>
    public Guid AuthorId { get; set; }

    /// <summary>Gets/sets an object that represents a name of an author.</summary>
    [Required]
    [MaxLength(255)]
    public string Name { get; set; }
  }
}
