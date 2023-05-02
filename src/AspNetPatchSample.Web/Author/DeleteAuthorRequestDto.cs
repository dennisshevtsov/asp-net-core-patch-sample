// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Author.Web
{
  using System.Text.Json.Serialization;

  using AspNetPatchSample.Web;

  /// <summary>Represents the DELETE author request data.</summary>
  public sealed class DeleteAuthorRequestDto : RequestDtoBase, IAuthorIdentity
  {
    /// <summary>Gets/sets an object that represents an ID of an author.</summary>
    [JsonPropertyName("authorId")]
    public Guid Id { get; set; }
  }
}
