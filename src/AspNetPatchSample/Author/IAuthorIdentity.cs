// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Author
{
  /// <summary>Represents an author identity.</summary>
  public interface IAuthorIdentity : IIdentity
  {
    /// <summary>Gets an object that represents an ID of author.</summary>
    public Guid AuthorId { get; }
  }
}
