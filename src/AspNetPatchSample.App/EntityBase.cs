// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.App
{
  public abstract class EntityBase
  {
    private readonly IList<string> _properties;

    protected EntityBase()
    {
      _properties = new List<string>();
    }

    public IEnumerable<string> Properties => _properties;
  }
}
