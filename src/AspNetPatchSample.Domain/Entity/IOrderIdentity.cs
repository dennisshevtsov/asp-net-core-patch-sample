// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Domain.Entity
{
  /// <summary>Represents an order identity.</summary>
  public interface IOrderIdentity
  {
    /// <summary>Gets an object that represents an ID of an order.</summary>
    public Guid OrderId { get; }
  }
}
