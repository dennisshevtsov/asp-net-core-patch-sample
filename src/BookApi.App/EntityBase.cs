// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Reflection;

namespace BookApi.App;

/// <summary>Represents an entity base.</summary>
public abstract class EntityBase : IComparable<object>
{
  /// <summary>Gets an object that represents a collection of related entities.</summary>
  public virtual string[] Relations() => Array.Empty<string>();

  /// <summary>Compares this entity.</summary>
  /// <param name="otherEntity">An object that represents an entity from which this entity should be compared.</param>
  /// <returns>An object that represents a collection of different properties.</returns>
  public string[] Compare(object otherEntity)
  {
    string[] updatingProperties = GetUpdatingProperties();
    string[] updatedProperties  = updatingProperties;

    return Update(otherEntity, updatedProperties, updatingProperties);
  }

  /// <summary>Compares this entity.</summary>
  /// <param name="otherEntity">An object that represents an entity from which this entity should be compared.</param>
  /// <param name="propertiesToCompare">An object that represents a collection of properties to compare.</param>
  /// <returns>An object that represents a collection of different properties.</returns>
  public string[] Compare(object otherEntity, string[] propertiesToCompare) =>
    Update(otherEntity, propertiesToCompare, GetUpdatingProperties());

  protected virtual string[] Update(object otherEntity, string[] propertiesToCompare, string[] updatingProperties)
  {
    string[] differentProperties  = new string[propertiesToCompare.Length];
    int differentPropertiesLength = 0;

    for (int i = 0; i < propertiesToCompare.Length; i++)
    {
      string property = propertiesToCompare[i];

      if (updatingProperties.Contains(property))
      {
        PropertyInfo originalProperty = GetType().GetProperty(property)!;
        PropertyInfo otherProperty    = otherEntity.GetType().GetProperty(property)!;

        object? originalValue = originalProperty.GetValue(this);
        object? otherValue    = otherProperty.GetValue(otherEntity);

        if (!object.Equals(originalValue, otherValue))
        {
          differentProperties[differentPropertiesLength++] = property;
        }
      }
    }

    Array.Resize(ref differentProperties, differentPropertiesLength);

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

  private string[] GetUpdatingProperties()
  {
    PropertyInfo[] allProperties = GetType().GetProperties();
    string[] updatingProperties  = new string[allProperties.Length];
    int updatingPropertiesLength = 0;

    for (int i = 0; i < allProperties.Length; i++)
    {
      if (allProperties[i].CanWrite)
      {
        updatingProperties[updatingPropertiesLength++] = allProperties[i].Name;
      }
    }

    Array.Resize(ref updatingProperties, updatingPropertiesLength);

    return updatingProperties;
  }
}
