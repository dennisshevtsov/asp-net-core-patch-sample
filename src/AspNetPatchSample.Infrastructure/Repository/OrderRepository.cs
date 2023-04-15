// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Infrastructure.Repository
{
  using Microsoft.EntityFrameworkCore;

  using AspNetPatchSample.Domain.Entity;
  using AspNetPatchSample.Domain.Repository;
  using AspNetPatchSample.Infrastructure.Entity;

  /// <summary>Provides a simple API to store instances of the <see cref="AspNetPatchSample.Domain.Entity.IOrderEntity"/>.</summary>
  public sealed class OrderRepository : IOrderRepository
  {
    private readonly DbContext _dbContext;

    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Infrastructure.Repository.OrderRepository"/> class.</summary>
    /// <param name="dbContext">An object that represents a session with the database and can be used to query and save instances of your entities.</param>
    public OrderRepository(DbContext dbContext)
    {
      _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    /// <summary>Gets an order.</summary>
    /// <param name="orderIdentity">An object that represents an order identity.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="AspNetPatchSample.Domain.Entity.IOrderEntity"/>. The result can be null.</returns>
    public async Task<IOrderEntity?> GetOrderAsync(IOrderIdentity orderIdentity, CancellationToken cancellationToken)
      => await _dbContext.Set<OrderEntity>()
                         .AsNoTracking()
                         .Where(entity => entity.OrderId == orderIdentity.OrderId)
                         .FirstOrDefaultAsync(cancellationToken);

    /// <summary>Adds an order.</summary>
    /// <param name="orderData">An object that reprents order data.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="AspNetPatchSample.Domain.Entity.IOrderEntity"/>.</returns>
    public async Task<IOrderEntity> AddOrderAsync(IOrderData orderData, CancellationToken cancellationToken)
    {
      var dbOrderEntity = new OrderEntity(orderData);
      var dbOrderEntityEntry = _dbContext.Entry(dbOrderEntity);

      dbOrderEntityEntry.State = EntityState.Added;
      await _dbContext.SaveChangesAsync(cancellationToken);
      dbOrderEntityEntry.State = EntityState.Detached;

      return dbOrderEntity;
    }

    /// <summary>Updates an order.</summary>
    /// <param name="orderEntity">An object that reprents an order entity.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public async Task UpdateOrderAsync(IOrderEntity orderEntity, CancellationToken cancellationToken)
    {
      var dbOrderEntity = new OrderEntity(orderEntity);
      var dbOrderEntityEntry = _dbContext.Entry(dbOrderEntity);

      dbOrderEntityEntry.State = EntityState.Modified;
      await _dbContext.SaveChangesAsync(cancellationToken);
      dbOrderEntityEntry.State = EntityState.Detached;
    }
  }
}
