// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Reflection;

namespace AspNetPatchSample.App
{
  /// <summary>Represents an entity base.</summary>
  public abstract class EntityBase : IUpdatable<object>
  {
    private ISet<string> _properties;

    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.App.Author.EntityBase"/> class.</summary>
    protected EntityBase()
    {
      _properties = new HashSet<string>();
    }

    /// <summary>Gets an object that represents a collection of properties to update.</summary>
    public IEnumerable<string> Properties { get => _properties; }

    /// <summary>Adds a property to a collection of properties to update.</summary>
    /// <param name="propertyName">An object that represents a name of a property.</param>
    protected void Updated(string propertyName) => _properties.Add(propertyName);

    /// <summary>Clears a collection properties to update.</summary>
    protected void Reset() => _properties.Clear();

    /// <summary>Updates this entity.</summary>
    /// <param name="newEntity">An object that represents an entity from which this entity should be updated.</param>
    /// <returns>A reference of this entity.</returns>
    public object Update(object newEntity)
    {
      var updatingProperties = UpdatingProperties();
      var updatedProperties = updatingProperties.ToHashSet(StringComparer.OrdinalIgnoreCase);

      return Update(newEntity, UpdatingProperties(), updatedProperties);
    }

    /// <summary>Updates this entity.</summary>
    /// <param name="newEntity">An object that represents an entity from which this entity should be updated.</param>
    /// <param name="properties">An object that represents a collection of properties to update.</param>
    /// <returns>A reference of this entity.</returns>
    public object Update(object newEntity, IEnumerable<string> properties)
    {
      return Update(newEntity, UpdatingProperties(), properties.ToHashSet(StringComparer.OrdinalIgnoreCase));
    }

    private string[] UpdatingProperties() =>
      GetType().GetProperties()
               .Where(property => property.SetMethod != null)
               .Select(property => property.Name)
               .ToArray();

    private object Update(
      object newEntity,
      IEnumerable<string> updatingProperties,
      ISet<string> updatedProperties)
    {
      Reset();

      foreach (var property in updatingProperties)
      {
        var originalProperty = GetType().GetProperty(property)!;
        var newProperty      = newEntity.GetType().GetProperty(property)!;

        var originalValue = originalProperty.GetValue(this);
        var newValue      = newProperty.GetValue(newEntity);

        if (originalValue != newValue && updatedProperties.Contains(property))
        {
          originalProperty.SetValue(this, newValue);
          Updated(property);
        }
      }

      return this;
    }
  }
}
