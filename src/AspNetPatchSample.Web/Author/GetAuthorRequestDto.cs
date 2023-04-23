// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Author.Web
{
  /// <summary>Represents the GET author request data.</summary>
  public sealed class GetAuthorRequestDto : IAuthorIdentity
  {
    /// <summary>Gets an object that represents an ID of author.</summary>
    public Guid AuthorId { get; }
  }
}
