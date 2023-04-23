// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Data
{
  /// <summary>Represents a base entity.</summary>
  public abstract class EntityBase
  {
    /// <summary>Gets/sets an object that represents an ID of an entity.</summary>
    public Guid Id { get; set; }
  }
}
