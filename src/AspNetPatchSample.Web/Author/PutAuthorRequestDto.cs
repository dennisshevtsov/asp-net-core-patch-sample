// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Author.Web
{
  using AspNetPatchSample.Web;

  /// <summary>Represents the PUT author request data.</summary>
  public sealed class PutAuthorRequestDto : RequestDtoBase, IAuthorEntity
  {
    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Author.Web.PutAuthorRequestDto"/> class.</summary>
    public PutAuthorRequestDto() : base()
    {
      Name = string.Empty;
    }

    /// <summary>Gets/sets an object that represents an ID of author.</summary>
    public Guid AuthorId { get; set; }

    /// <summary>Gets/sets an object that represents a name of an author.</summary>
    public string Name { get; set; }

    /// <summary>Converts this object to an instance of the <see cref="System.Guid"/>.</summary>
    /// <returns>An object that represents a Globally Unique Identifier.</returns>
    public Guid ToGuid() => AuthorId;
  }
}
