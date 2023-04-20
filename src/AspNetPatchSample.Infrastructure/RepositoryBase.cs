﻿// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Infrastructure
{
  using Microsoft.EntityFrameworkCore;
  using AspNetPatchSample.Domain;

  /// <summary>Provides a simple API to store instances of the <see cref="TInterface"/>.</summary>
  /// <typeparam name="TInterface">Type of an entity.</typeparam>
  public abstract class RepositoryBase<TInterface, TImplementation> : IRepository<TInterface>
  where TImplementation : TInterface
  where TInterface : class
  {
    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Infrastructure.RepositoryBase{TInterface, TImplementation}"/> class.</summary>
    /// <param name="dbContext">An object that represents a session with the database and can be used to query and save instances of your entities.</param>
    public RepositoryBase(DbContext dbContext)
    {
      DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    protected DbContext DbContext { get; }

    /// <summary>Adds an entity.</summary>
    /// <param name="entity">An object that reprents an entity.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="Domain.Book.IBookEntity"/>.</returns>
    public virtual async Task<TInterface> AddAsync(TInterface entity, CancellationToken cancellationToken)
    {
      var dbEntity = Create(entity);
      var dbEntityEntry = DbContext.Entry(dbEntity);

      dbEntityEntry.State = EntityState.Added;
      await DbContext.SaveChangesAsync(cancellationToken);
      dbEntityEntry.State = EntityState.Detached;

      return dbEntity;
    }

    /// <summary>Updates an entity.</summary>
    /// <param name="entity">An object that represents an entity.</param>
    /// <param name="properties">An object that represents a collection of properties to update.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public virtual async Task UpdateAsync(TInterface entity, string[] properties, CancellationToken cancellationToken)
    {
      var dbEntity = Create(entity);
      var dbEntityEntry = DbContext.Entry(dbEntity);

      for (int i = 0; i < properties.Length; i++)
      {
        dbEntityEntry.Property(properties[i]).IsModified = true;
      }

      await DbContext.SaveChangesAsync(cancellationToken);
      dbEntityEntry.State = EntityState.Detached;
    }

    protected virtual TImplementation Create(TInterface entity)
      => (TImplementation)Activator.CreateInstance(typeof(TImplementation), entity)!;
  }
}