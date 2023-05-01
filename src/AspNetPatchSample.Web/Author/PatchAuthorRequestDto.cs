// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Author.Web
{
  using AspNetPatchSample.Web;
  using System.Text.Json.Serialization;

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
    [JsonIgnore]
    public IEnumerable<string> Properties { get; set; }

    /// <summary>Converts this object to an instance of the <see cref="System.Guid"/>.</summary>
    /// <returns>An object that represents a Globally Unique Identifier.</returns>
    public Guid ToGuid() => AuthorId;
  }
}
