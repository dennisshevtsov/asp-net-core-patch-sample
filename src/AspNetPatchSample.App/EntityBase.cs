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
  }
}
