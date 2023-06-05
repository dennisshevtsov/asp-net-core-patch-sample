// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.App
{
  /// <summary>Represents an entity base.</summary>
  public abstract class EntityBase
  {
    private readonly IList<string> _properties;

    /// <summary>Initializes a new instance of the <see cref="EntityBase"/> class.</summary>
    protected EntityBase()
    {
      _properties = new List<string>();
    }

    /// <summary>Gets/sets an object that represents a collection of updated properties.</summary>
    public IEnumerable<string> Properties => _properties;

    /// <summary>Creates a copy of an entity.</summary>
    /// <param name="entity">An object that represents an entity to copy.</param>
    /// <returns>An object that represents an instance of an entity copy.</returns>
    /// <exception cref="System.NotSupportedException">Throws if there is no such entity.</exception>
    public static T2 Create<T1, T2>(T1 entity) where T2 : EntityBase, T1
    {
      ArgumentNullException.ThrowIfNull(entity);

      if (entity.GetType() == typeof(T2))
      {
        return (T2)entity;
      }

      return (T2)typeof(T2).GetConstructor(new[] { typeof(T1) })!
                           .Invoke(new object[] { entity! });
    }
  }
}
