﻿// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Author.Web
{
  using AspNetPatchSample.Web;

  /// <summary>Represents the PATCH author request data.</summary>
  public sealed class PatchAuthorRequestDto : IAuthorEntity, IPatchable
  {
    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Author.Web.PatchAuthorRequestDto"/> class.</summary>
    public PatchAuthorRequestDto()
    {
      Name       = string.Empty;
      Properties = Array.Empty<string>();
    }

    /// <summary>Gets/sets an object that represents an ID of author.</summary>
    public Guid AuthorId { get; set; }

    /// <summary>Gets/sets an object that represents a name of an author.</summary>
    public string Name { get; set; }

    /// <summary>Gets an object that represents a collection of properties to update.</summary>
    public string[] Properties { get; set; }
  }
}
