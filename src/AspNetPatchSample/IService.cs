// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample
{
  /// <summary>Provides a simple GRUD API.</summary>
  /// <typeparam name="TIdentity">An identity type.</typeparam>
  /// <typeparam name="TData">An data type.</typeparam>
  /// <typeparam name="TEntity">An entity type.</typeparam>
  public interface IService<TIdentity, TData, TEntity>
  {
    /// <summary>Gets an entity.</summary>
    /// <param name="identity">An object that represents an identity to get.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="AspNetPatchSample.Author.IAuthorEntity"/>. The result can be null.</returns>
    public Task<TEntity?> GetAsync(TIdentity identity, CancellationToken cancellationToken);

    /// <summary>Adds an entity.</summary>
    /// <param name="data">An object that represents data from that a new entity should be created.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="AspNetPatchSample.Author.IAuthorEntity"/>.</returns>
    public Task<TEntity> AddAsync(TData data, CancellationToken cancellationToken);

    /// <summary>Updates an entity.</summary>
    /// <param name="originalEntity">An object that represents an entity to update.</param>
    /// <param name="newEntity">An object that represents an entity from that the original one should be updated.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public Task UpdateAsync(TEntity originalEntity, TEntity newEntity, CancellationToken cancellationToken);

    /// <summary>Updates an entity partially.</summary>
    /// <param name="originalEntity">An object that represents an entity to update.</param>
    /// <param name="newEntity">An object that represents an entity from that the original one should be updated.</param>
    /// <param name="properties">An object that represents a collection of properties to update.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public Task UpdateAsync(TEntity originalEntity, TEntity newEntity, string[] properties, CancellationToken cancellationToken);

    /// <summary>Deletes an entity.</summary>
    /// <param name="identity">An object that represents an identity to delete.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public Task DeleteAsync(TIdentity identity, CancellationToken cancellationToken);
  }
}
