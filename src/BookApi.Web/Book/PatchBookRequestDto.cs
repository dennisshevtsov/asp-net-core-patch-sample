// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace BookApi.Book.Web
{
  using System.ComponentModel.DataAnnotations;
  using System.Text.Json.Serialization;

  using BookApi.Author;
  using BookApi.Web;

  /// <summary>Represents data to update a book parially.</summary>
  public sealed class PatchBookRequestDto : IRequestDto, IPatchRequestDto, IBookEntity
  {
    /// <summary>Initalizes a new instance of the <see cref="BookApi.Book.Web.PatchBookRequestDto"/> class.</summary>
    public PatchBookRequestDto()
    {
      Title       = string.Empty;
      Description = string.Empty;
      Properties  = Array.Empty<string>();
      BookAuthors = Array.Empty<AuthorDto>();
    }

    /// <summary>Gets an objecct that represents an ID of a book.</summary>
    public Guid BookId { get; set; }

    /// <summary>Gets an object that represents a title of a book.</summary>
    [Required]
    [MaxLength(255)]
    public string Title { get; set; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    [Required]
    [MaxLength(255)]
    public string Description { get; set; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    public int Pages { get; set; }

    /// <summary>Gets an object that represents a collection of authors of this book.</summary>
    [JsonPropertyName("authors")]
    public IEnumerable<AuthorDto> BookAuthors { get; set; }

    /// <summary>Gets an object that represents a collection of authors of this book.</summary>
    [JsonIgnore]
    public IEnumerable<IAuthorEntity> Authors => BookAuthors;

    /// <summary>Gets an object that represents a collection of properties to update.</summary>
    [JsonIgnore]
    public IEnumerable<string> Properties { get; set; }
  }
}
