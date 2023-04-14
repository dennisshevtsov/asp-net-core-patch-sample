// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Domain.Repository
{
  using AspNetPatchSample.Domain.Entity;

  /// <summary>Provides a simple API to store instances of the <see cref="AspNetPatchSample.Domain.Entity.IOrderEntity"/>.</summary>
  public interface IOrderRepository
  {
    /// <summary>Gets an order.</summary>
    /// <param name="orderIdentity">An object that represents an order identity.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="AspNetPatchSample.Domain.Entity.IOrderEntity"/>.</returns>
    public Task<IOrderEntity> GetOrderAsync(IOrderIdentity orderIdentity, CancellationToken cancellationToken);

    /// <summary>Updates an order.</summary>
    /// <param name="orderEntity"></param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public Task UpdateAsync(IOrderEntity orderEntity, CancellationToken cancellationToken);
  }
}
