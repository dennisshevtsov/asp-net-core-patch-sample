// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Author.Web
{
  using System.Text.Json.Serialization;

  using AspNetPatchSample.Web;

  /// <summary>Represents an author DTO base.</summary>
  public abstract class AuthorRequestDtoBase : RequestDtoBase, IAuthorIdentity
  {
    /// <summary>Gets/sets an object that represents an ID of an author.</summary>
    [JsonIgnore]
    public Guid Id { get => AuthorId; set => AuthorId = value; }

    /// <summary>Gets an objecct that represents an ID of an author.</summary>
    public Guid AuthorId { get; set; }
  }
}
