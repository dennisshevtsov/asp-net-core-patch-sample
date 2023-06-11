// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace BookApi.Author.Web
{
  using System.ComponentModel.DataAnnotations;
  using System.Text.Json.Serialization;

  using BookApi.Web;

  /// <summary>Represents the POST author request data.</summary>
  public sealed class PostAuthorRequestDto : IRequestDto, IAuthorEntity
  {
    /// <summary>Initializes a new instance of the <see cref="BookApi.Author.Web.PostAuthorRequestDto"/> class.</summary>
    public PostAuthorRequestDto()
    {
      Name = string.Empty;
    }

    /// <summary>Gets an objecct that represents an ID of an author.</summary>
    [JsonIgnore]
    public Guid AuthorId { get; set; }

    /// <summary>Gets/sets an object that represents a name of an author.</summary>
    [Required]
    public string Name { get; set; }
  }
}
