// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.App
{
  /// <summary>Represents an entity base.</summary>
  public abstract class EntityBase
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
  }
}
