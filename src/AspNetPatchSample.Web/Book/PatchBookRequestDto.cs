// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Book.Web
{
  using AspNetPatchSample.Web;

  /// <summary>Represents data to update a book parially.</summary>
  public sealed class PatchBookRequestDto : IBookEntity, IPatchable
  {
    /// <summary>Initalizes a new instance of the <see cref="AspNetPatchSample.Web.Dtos.PatchBookRequestDto"/> class.</summary>
    public PatchBookRequestDto()
    {
      Title       = string.Empty;
      Author      = string.Empty;
      Description = string.Empty;
      Properties  = Array.Empty<string>();
    }

    /// <summary>Gets an object that represents an ID of a book.</summary>
    public Guid BookId { get; set; }

    /// <summary>Gets an object that represents a title of a book.</summary>
    public string Title { get; set; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    public string Author { get; set; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    public string Description { get; set; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    public int Pages { get; set; }

    /// <summary>Gets an object that represents a collection of properties to update.</summary>
    public string[] Properties { get; set; }

    /// <summary>Converts this object to an instance of the <see cref="System.Guid"/>.</summary>
    /// <returns>An object that represents a Globally Unique Identifier.</returns>
    public Guid ToGuid() => BookId;
  }
}
