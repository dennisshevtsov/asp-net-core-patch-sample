// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.App
{
  /// <summary>Provides a simple GRUD API.</summary>
  /// <typeparam name="TIdentity">An identity type.</typeparam>
  /// <typeparam name="TData">An data type.</typeparam>
  /// <typeparam name="TEntity">An entity type.</typeparam>
  public abstract class ServiceBase<TIdentity, TData, TEntity>
    : IService<TIdentity, TData, TEntity>
    where TIdentity : IIdentity
    where TEntity   : class, IUpdatable<TEntity>
  {
    private readonly IRepository<TEntity> _repository;

    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.App.ServiceBase{TEntity, TData, TEntity}"/> class.</summary>
    /// <param name="repository">An object that provides a simple API to store instances of the <see cref="TEntity"/>.</param>
    protected ServiceBase(IRepository<TEntity> repository)
    {
      _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    /// <summary>Gets an entity.</summary>
    /// <param name="identity">An object that represents an identity to get.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="AspNetPatchSample.Author.IAuthorEntity"/>. The result can be null.</returns>
    public Task<TEntity?> GetAsync(TIdentity identity, CancellationToken cancellationToken)
      => _repository.GetAsync(identity, cancellationToken);

    /// <summary>Adds an entity.</summary>
    /// <param name="data">An object that represents data from that a new entity should be created.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="AspNetPatchSample.Author.IAuthorEntity"/>.</returns>
    public Task<TEntity> AddAsync(TData data, CancellationToken cancellationToken)
      => _repository.AddAsync((TEntity)Activator.CreateInstance(typeof(TEntity), data)!, cancellationToken);

    /// <summary>Updates an entity.</summary>
    /// <param name="originalEntity">An object that represents an entity to update.</param>
    /// <param name="newEntity">An object that represents an entity from that the original one should be updated.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public Task UpdateAsync(TEntity originalEntity, TEntity newEntity, CancellationToken cancellationToken)
    {
      var buisinessEntity = (TEntity)Activator.CreateInstance(typeof(TEntity), originalEntity)!;
      buisinessEntity.Update(newEntity);

      return _repository.UpdateAsync(buisinessEntity, Array.Empty<string>(), cancellationToken);
    }

    /// <summary>Updates an entity partially.</summary>
    /// <param name="originalEntity">An object that represents an entity to update.</param>
    /// <param name="newEntity">An object that represents an entity from that the original one should be updated.</param>
    /// <param name="properties">An object that represents a collection of properties to update.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public Task UpdateAsync(TEntity originalEntity, TEntity newEntity, string[] properties, CancellationToken cancellationToken)
    {
      var buisinessEntity = (TEntity)Activator.CreateInstance(typeof(TEntity), originalEntity)!;
      buisinessEntity.Update(newEntity, properties);

      return _repository.UpdateAsync(buisinessEntity, properties, cancellationToken);
    }


    /// <summary>Deletes an entity.</summary>
    /// <param name="identity">An object that represents an identity to delete.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public Task DeleteAsync(TIdentity identity, CancellationToken cancellationToken)
      => _repository.DeleteAsync(identity, cancellationToken);
  }
}
