﻿// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Author.Web
{
  using System.Text.Json.Serialization;

  /// <summary>Represents the POST author request data.</summary>
  public sealed class PostAuthorRequestDto : IAuthorEntity
  {
    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Author.Web.PostAuthorRequestDto"/> class.</summary>
    public PostAuthorRequestDto()
    {
      Name = string.Empty;
    }

    /// <summary>Gets an object that represents an ID of author.</summary>
    [JsonIgnore]
    public Guid AuthorId => Guid.Empty;

    /// <summary>Gets/sets an object that represents a name of an author.</summary>
    public string Name { get; set; }

    /// <summary>Converts this object to an instance of the <see cref="System.Guid"/>.</summary>
    /// <returns>An object that represents a Globally Unique Identifier.</returns>
    public Guid ToGuid() => AuthorId;
  }
}
