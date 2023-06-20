// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using BookApi.Author;

namespace BookApi.Book.Web;

/// <summary>Represents an author entity.</summary>
public sealed class AuthorDto : IAuthorEntity
{
  /// <summary>Initializes a new instance of the <see cref="BookApi.Book.Web.AuthorDto"/> class.</summary>
  public AuthorDto()
  {
    Name = string.Empty;
  }

  /// <summary>Gets an object that represents an ID of an author.</summary>
  public Guid AuthorId { get; set; }

  /// <summary>Gets an object that represents a name of an author.</summary>
  public string Name { get; set; }
}
