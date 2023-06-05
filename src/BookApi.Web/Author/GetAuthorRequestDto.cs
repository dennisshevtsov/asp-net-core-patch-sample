// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace BookApi.Author.Web
{
  using BookApi.Web;

  /// <summary>Represents the GET author request data.</summary>
  public sealed class GetAuthorRequestDto : IRequestDto, IAuthorIdentity
  {
    /// <summary>Initializes a new instance of the <see cref="BookApi.Author.Web.GetAuthorRequestDto"/> class.</summary>
    public GetAuthorRequestDto() { }

    /// <summary>Initializes a new instance of the <see cref="BookApi.Author.Web.GetAuthorRequestDto"/> class.</summary>
    /// <param name="authorIdentity">An object that represents an author identity.</param>
    public GetAuthorRequestDto(IAuthorIdentity authorIdentity) : this()
    {
      AuthorId = authorIdentity.AuthorId;
    }

    /// <summary>Gets an objecct that represents an ID of an author.</summary>
    public Guid AuthorId { get; set; }
  }
}
