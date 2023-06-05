// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace BookApi.Author
{
  /// <summary>Represents an author entity.</summary>
  public interface IAuthorEntity : IAuthorIdentity
  {
    /// <summary>Gets an object that represents a name of an author.</summary>
    public string Name { get; }
  }
}
