// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.App
{
  /// <summary>Represents contract to update an entity.</summary>
  public interface IUpdatable<TEntity>
  {
    /// <summary>Updates this entity.</summary>
    /// <param name="newEntity">An object that represents an entity from which this entity should be updated.</param>
    /// <returns>A reference of this entity.</returns>
    public TEntity Update(TEntity newEntity);

    /// <summary>Updates this entity.</summary>
    /// <param name="newEntity">An object that represents an entity from which this entity should be updated.</param>
    /// <param name="properties">An object that represents a collection of properties to update.</param>
    /// <returns>A reference of this entity.</returns>
    public TEntity Update(TEntity newEntity, IEnumerable<string> properties);
  }
}
