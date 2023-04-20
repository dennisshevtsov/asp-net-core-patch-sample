// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Domain.Entity
{
  /// <summary>Represents an author identity.</summary>
  public interface IAuthorIdentity
  {
    /// <summary>Gets an object that represents an ID of author.</summary>
    public Guid AuthorId { get; }
  }
}
