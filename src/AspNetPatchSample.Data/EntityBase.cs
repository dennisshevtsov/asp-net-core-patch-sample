// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Data
{
  /// <summary>Represents a base entity.</summary>
  public abstract class EntityBase : IIdentity
  {
    /// <summary>Gets/sets an object that represents an ID of an entity.</summary>
    public Guid Id { get; set; }

    /// <summary>Determines whether the specified object is equal to the current object.</summary>
    /// <param name="obj">The object to compare with the current object</param>
    /// <returns>An object that indicates if it equals to an comparing object.</returns>
    public override bool Equals(object? obj)
    {
      if (obj is IIdentity identity)
      {
        return identity.Id == Id;
      }

      return false;
    }

    /// <summary>Serves as the default hash function.</summary>
    /// <returns>A hash code for the current object.</returns>
    public override int GetHashCode() => Id.GetHashCode();
  }
}
