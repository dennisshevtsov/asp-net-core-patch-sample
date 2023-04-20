// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Domain.Author
{
  /// <summary>Represents author data.</summary>
  public interface IAuthorData
  {
    /// <summary>Gets an object that represents a name of an author.</summary>
    public string Name { get; }
  }
}
