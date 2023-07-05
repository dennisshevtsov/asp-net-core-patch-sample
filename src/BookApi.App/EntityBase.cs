// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Reflection;

namespace BookApi.App;

/// <summary>Represents an entity base.</summary>
public abstract class EntityBase : IComparable<object>
{
  /// <summary>Gets an object that represents a collection of related entities.</summary>
  public IEnumerable<string> Relations() =>
    GetType().GetProperties()
             .Where(property => !property.PropertyType.IsValueType)
             .Where(property => property.PropertyType != typeof(string))
             .Select(property => property.Name)
             .ToHashSet(StringComparer.OrdinalIgnoreCase);

  /// <summary>Compares this entity.</summary>
  /// <param name="otherEntity">An object that represents an entity from which this entity should be compared.</param>
  /// <returns>An object that represents a collection of different properties.</returns>
  public IEnumerable<string> Compare(object otherEntity)
  {
    ISet<string> updatingProperties = GetUpdatingProperties();
    ISet<string> updatedProperties  = updatingProperties;

    return Update(otherEntity, updatedProperties, updatingProperties);
  }

  /// <summary>Compares this entity.</summary>
  /// <param name="otherEntity">An object that represents an entity from which this entity should be compared.</param>
  /// <param name="propertiesToCompare">An object that represents a collection of properties to compare.</param>
  /// <returns>An object that represents a collection of different properties.</returns>
  public IEnumerable<string> Compare(object otherEntity, IEnumerable<string> propertiesToCompare) =>
    Update(otherEntity, propertiesToCompare, GetUpdatingProperties());

  protected virtual IEnumerable<string> Update(object otherEntity, IEnumerable<string> propertiesToCompare, ISet<string> updatingProperties)
  {
    List<string> differentProperties = new();

    foreach (string property in propertiesToCompare)
    {
      if (updatingProperties.Contains(property))
      {
        PropertyInfo originalProperty = GetType().GetProperty(property)!;
        PropertyInfo otherProperty    = otherEntity.GetType().GetProperty(property)!;

        object? originalValue = originalProperty.GetValue(this);
        object? otherValue    = otherProperty.GetValue(otherEntity);

        if (!object.Equals(originalValue, otherValue))
        {
          differentProperties.Add(property);
        }
      }
    }

    return differentProperties;
  }

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

  private ISet<string> GetUpdatingProperties() =>
    GetType().GetProperties()
             .Where(property => property.CanWrite)
             .Select(property => property.Name)
             .ToHashSet(StringComparer.OrdinalIgnoreCase);
}
