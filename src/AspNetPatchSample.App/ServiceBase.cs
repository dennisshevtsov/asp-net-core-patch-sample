// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.App
{
  /// <summary>Provides a simple GRUD API.</summary>
  /// <typeparam name="TIdentity">An identity type.</typeparam>
  /// <typeparam name="TDomainEntity">A domain entity type.</typeparam>
  /// <typeparam name="TBusinessEntity">A buisiness entity type.</typeparam>
  public abstract class ServiceBase<TIdentity, TDomainEntity, TBusinessEntity>
    : IService<TIdentity, TDomainEntity>
    where TIdentity : IIdentity
    where TDomainEntity : class
    where TBusinessEntity : EntityBase, TDomainEntity, IUpdatable<TDomainEntity>
  {
    private readonly IRepository<TDomainEntity> _repository;

    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.App.ServiceBase{TEntity, TData, TEntity}"/> class.</summary>
    /// <param name="repository">An object that provides a simple API to store instances of the <see cref="TEntity"/>.</param>
    protected ServiceBase(IRepository<TDomainEntity> repository)
    {
      _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    /// <summary>Gets an entity.</summary>
    /// <param name="identity">An object that represents an identity to get.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="AspNetPatchSample.Author.IAuthorEntity"/>. The result can be null.</returns>
    public virtual Task<TDomainEntity?> GetAsync(TIdentity identity, CancellationToken cancellationToken)
      => _repository.GetAsync(identity, cancellationToken);

    /// <summary>Adds an entity.</summary>
    /// <param name="data">An object that represents data from that a new entity should be created.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="AspNetPatchSample.Author.IAuthorEntity"/>.</returns>
    public virtual Task<TDomainEntity> AddAsync(TDomainEntity data, CancellationToken cancellationToken)
      => _repository.AddAsync((TBusinessEntity)Activator.CreateInstance(typeof(TBusinessEntity), data)!, cancellationToken);

    /// <summary>Updates an entity.</summary>
    /// <param name="originalEntity">An object that represents an entity to update.</param>
    /// <param name="newEntity">An object that represents an entity from that the original one should be updated.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public virtual Task UpdateAsync(TDomainEntity originalEntity, TDomainEntity newEntity, CancellationToken cancellationToken)
    {
      var buisinessEntity = (TBusinessEntity)Activator.CreateInstance(typeof(TBusinessEntity), originalEntity)!;
      buisinessEntity.Update(newEntity);

      return _repository.UpdateAsync(buisinessEntity, buisinessEntity.Properties, cancellationToken);
    }

    /// <summary>Updates an entity partially.</summary>
    /// <param name="originalEntity">An object that represents an entity to update.</param>
    /// <param name="newEntity">An object that represents an entity from that the original one should be updated.</param>
    /// <param name="properties">An object that represents a collection of properties to update.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public virtual Task UpdateAsync(TDomainEntity originalEntity, TDomainEntity newEntity, IEnumerable<string> properties, CancellationToken cancellationToken)
    {
      var buisinessEntity = (TBusinessEntity)Activator.CreateInstance(typeof(TBusinessEntity), originalEntity)!;
      buisinessEntity.Update(newEntity, properties);

      return _repository.UpdateAsync(buisinessEntity, properties, cancellationToken);
    }

    /// <summary>Deletes an entity.</summary>
    /// <param name="identity">An object that represents an identity to delete.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public virtual Task DeleteAsync(TIdentity identity, CancellationToken cancellationToken)
      => _repository.DeleteAsync(identity, cancellationToken);
  }
}
