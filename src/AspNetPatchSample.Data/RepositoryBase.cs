// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Data
{
  using Microsoft.EntityFrameworkCore;
  
  using AspNetPatchSample;

  /// <summary>Provides a simple API to store instances of the <see cref="TInterface"/>.</summary>
  /// <typeparam name="TInterface">Type of an entity.</typeparam>
  public abstract class RepositoryBase<TInterface, TImplementation> : IRepository<TInterface>
    where TImplementation : EntityBase, TInterface, new()
    where TInterface      : class, IIdentity
  {
    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Data.RepositoryBase{TInterface, TImplementation}"/> class.</summary>
    /// <param name="dbContext">An object that represents a session with the database and can be used to query and save instances of your entities.</param>
    public RepositoryBase(DbContext dbContext)
    {
      DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    protected DbContext DbContext { get; }

    /// <summary>Gets an entity by its ID.</summary>
    /// <param name="identity">An object that represents an identity.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="TEntity"/>. The result can be null.</returns>
    public virtual async Task<TInterface?> GetAsync(IIdentity identity, CancellationToken cancellationToken)
    {
      return await DbContext.Set<TImplementation>()
                            .AsNoTracking()
                            .Where(entity => entity.Id == identity.Id)
                            .SingleOrDefaultAsync(cancellationToken);
    }

    /// <summary>Adds an entity.</summary>
    /// <param name="entity">An object that reprents an entity.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="Domain.Book.IBookEntity"/>.</returns>
    public virtual async Task<TInterface> AddAsync(TInterface entity, CancellationToken cancellationToken)
    {
      var dbEntity = Create(entity);
      var dbEntityEntry = DbContext.Entry(dbEntity);

      dbEntityEntry.State = EntityState.Added;

      foreach (var collectionEntry in dbEntityEntry.Collections)
      {
        if (collectionEntry.CurrentValue != null)
        {
          foreach (var collectionItemEntity in collectionEntry.CurrentValue)
          {
            DbContext.Entry(collectionItemEntity).State = EntityState.Unchanged;
          }
        }
      }

      await DbContext.SaveChangesAsync(cancellationToken);
      dbEntityEntry.State = EntityState.Detached;

      return dbEntity;
    }

    /// <summary>Updates an entity.</summary>
    /// <param name="entity">An object that represents an entity.</param>
    /// <param name="properties">An object that represents a collection of properties to update.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public virtual async Task UpdateAsync(TInterface entity, IEnumerable<string> properties, CancellationToken cancellationToken)
    {
      var sourceEntity      = Create(entity);
      var destinationEntity = new TImplementation();
      destinationEntity.Id  = entity.Id;

      await MergeAsync(sourceEntity, destinationEntity, properties, cancellationToken);
      await DbContext.SaveChangesAsync(cancellationToken);

      DbContext.Entry(destinationEntity).State = EntityState.Detached;
    }

    /// <summary>Deletes an entity by its ID.</summary>
    /// <param name="identity">An object that represents an identity.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public async Task DeleteAsync(IIdentity identity, CancellationToken cancellationToken)
    {
      var entity = await DbContext.Set<TImplementation>()
                                  .Where(entity => entity.Id == identity.Id)
                                  .SingleOrDefaultAsync(cancellationToken);

      if (entity != null)
      {
        DbContext.Entry(entity).State = EntityState.Deleted;
        await DbContext.SaveChangesAsync(cancellationToken);
      }
    }

    protected virtual TImplementation Create(TInterface entity)
      => (TImplementation)Activator.CreateInstance(typeof(TImplementation), entity)!;

    protected virtual Task MergeAsync(
      TImplementation source,
      TImplementation desctination,
      IEnumerable<string> properties,
      CancellationToken cancellationToken)
    {
      return Task.CompletedTask;
    }
  }
}
