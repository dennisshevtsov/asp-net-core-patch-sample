// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using AspNetPatchSample.Domain.Entity;

namespace AspNetPatchSample.Domain.Service
{
  /// <summary>Represents a simple API to operate instances of the <see cref="AspNetPatchSample.Domain.Entity.IOrderEntity"/>.</summary>
  public interface IOrderService
  {
    /// <summary>Gets an order.</summary>
    /// <param name="orderIdentity">An object that represents an order identity.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="AspNetPatchSample.Domain.Entity.IOrderEntity"/>. The result can be null.</returns>
    public Task<IOrderEntity?> GetOrderAsync(IOrderIdentity orderIdentity, CancellationToken cancellationToken);

    /// <summary>Adds an order.</summary>
    /// <param name="orderData">An object that reprents order data.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="AspNetPatchSample.Domain.Entity.IOrderEntity"/>.</returns>
    public Task<IOrderEntity> AddOrderAsync(IOrderData orderData, CancellationToken cancellationToken);

    /// <summary>Updates an order.</summary>
    /// <param name="orderEntity">An object that reprents an order entity.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public Task UpdateOrderAsync(IOrderEntity orderEntity, CancellationToken cancellationToken);
  }
}
