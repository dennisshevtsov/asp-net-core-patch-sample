// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Author.Web
{
  using System.Text.Json.Serialization;

  using AspNetPatchSample.Web;

  /// <summary>Represents the GET author request data.</summary>
  public sealed class GetAuthorRequestDto : AuthorRequestDtoBase, IAuthorIdentity
  {
    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Author.Web.GetAuthorRequestDto"/> class.</summary>
    public GetAuthorRequestDto() : base() { }

    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Author.Web.GetAuthorRequestDto"/> class.</summary>
    /// <param name="authorIdentity">An object that represents an author identity.</param>
    public GetAuthorRequestDto(IAuthorIdentity authorIdentity) : this()
    {
      Id = authorIdentity.Id;
    }
  }
}
