// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Infrastructure.Entity
{
  using AspNetPatchSample.Domain.Entity;

  /// <summary>Represents an order entity.</summary>
  public sealed class OrderEntity : IOrderEntity
  {
    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Infrastructure.Entity.OrderEntity"/> class.</summary>
    public OrderEntity()
    {
      Name = string.Empty;
    }

    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Infrastructure.Entity.OrderEntity"/> class.</summary>
    /// <param name="orderData">An object that represents order data.</param>
    public OrderEntity(IOrderData orderData)
    {
      Name = orderData.Name;
      Description = orderData.Description;
    }

    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Infrastructure.Entity.OrderEntity"/> class.</summary>
    /// <param name="orderData">An object that represents an order entity.</param>
    public OrderEntity(IOrderEntity orderEntity)
    {
      OrderId = orderEntity.OrderId;
      Name = orderEntity.Name;
      Description = orderEntity.Description;
    }

    /// <summary>Gets/sets an object that represents an ID of an order.</summary>
    public Guid OrderId { get; set; }

    /// <summary>Gets/sets an object that represents an order name.</summary>
    public string Name { get; set; }

    /// <summary>Gets/sets an object that represents an order description.</summary>
    public string? Description { get; set; }
  }
}
