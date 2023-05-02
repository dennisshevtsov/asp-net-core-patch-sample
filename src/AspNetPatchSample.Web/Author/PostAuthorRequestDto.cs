// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Author.Web
{
  using System.Text.Json.Serialization;

  using AspNetPatchSample.Web;

  /// <summary>Represents the POST author request data.</summary>
  public sealed class PostAuthorRequestDto : RequestDtoBase, IAuthorEntity
  {
    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Author.Web.PostAuthorRequestDto"/> class.</summary>
    public PostAuthorRequestDto() : base()
    {
      Name = string.Empty;
    }

    /// <summary>Gets an object that represents an ID of an author.</summary>
    [JsonIgnore]
    public Guid Id => Guid.Empty;

    /// <summary>Gets/sets an object that represents a name of an author.</summary>
    public string Name { get; set; }
  }
}
