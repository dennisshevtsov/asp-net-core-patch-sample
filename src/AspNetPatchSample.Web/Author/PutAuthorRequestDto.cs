// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Author.Web
{
  /// <summary>Represents the PUT author request data.</summary>
  public sealed class PutAuthorRequestDto : AuthorRequestDtoBase, IAuthorEntity
  {
    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Author.Web.PutAuthorRequestDto"/> class.</summary>
    public PutAuthorRequestDto() : base()
    {
      Name = string.Empty;
    }

    /// <summary>Gets/sets an object that represents a name of an author.</summary>
    public string Name { get; set; }
  }
}
