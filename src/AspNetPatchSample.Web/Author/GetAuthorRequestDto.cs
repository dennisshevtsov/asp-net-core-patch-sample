// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Author.Web
{
  using AspNetPatchSample.Web;

  /// <summary>Represents the GET author request data.</summary>
  public sealed class GetAuthorRequestDto : RequestDtoBase, IAuthorIdentity
  {
    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Author.Web.GetAuthorRequestDto"/> class.</summary>
    public GetAuthorRequestDto() : base() { }

    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Author.Web.GetAuthorRequestDto"/> class.</summary>
    /// <param name="authorIdentity">An object that represents an author identity.</param>
    public GetAuthorRequestDto(IAuthorIdentity authorIdentity) : this()
    {
      AuthorId = authorIdentity.AuthorId;
    }

    /// <summary>Gets/sets an object that represents an ID of author.</summary>
    public Guid AuthorId { get; set; }

    /// <summary>Converts this object to an instance of the <see cref="System.Guid"/>.</summary>
    /// <returns>An object that represents a Globally Unique Identifier.</returns>
    public Guid ToGuid() => AuthorId;
  }
}
