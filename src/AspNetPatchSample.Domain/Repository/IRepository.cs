// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Domain.Repository
{
  /// <summary>Provides a simple API to store instances of the <see cref="TEntity"/>.</summary>
  /// <typeparam name="TEntity">Type of an entity.</typeparam>
  public interface IRepository<TEntity> where TEntity : class
  {
    /// <summary>Stores an entity.</summary>
    /// <param name="entity">An object that reprents an entity.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="TEntity"/>.</returns>
    public Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);

    /// <summary>Updates an entity.</summary>
    /// <param name="entity">An object that represents an entity.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
  }
}
