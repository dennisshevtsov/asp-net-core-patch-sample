// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Domain.Entity
{
  /// <summary>Represents order data.</summary>
  public interface IOrderData
  {
    /// <summary>Gets an object that represents an order name.</summary>
    public string Name { get; }

    /// <summary>Gets an object that represents an order description.</summary>
    public string? Description { get; }
  }
}
