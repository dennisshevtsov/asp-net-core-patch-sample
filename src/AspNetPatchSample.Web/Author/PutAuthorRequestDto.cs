// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Author.Web
{
  using System.Text.Json.Serialization;

  using AspNetPatchSample.Web;

  /// <summary>Represents the PUT author request data.</summary>
  public sealed class PutAuthorRequestDto : RequestDtoBase, IAuthorEntity
  {
    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Author.Web.PutAuthorRequestDto"/> class.</summary>
    public PutAuthorRequestDto() : base()
    {
      Name = string.Empty;
    }

    /// <summary>Gets/sets an object that represents an ID of an author.</summary>
    [JsonPropertyName("authorId")]
    public Guid Id { get; set; }

    /// <summary>Gets/sets an object that represents a name of an author.</summary>
    public string Name { get; set; }
  }
}
