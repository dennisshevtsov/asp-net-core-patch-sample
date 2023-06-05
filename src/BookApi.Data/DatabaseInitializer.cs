// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace BookApi.Data
{
  using Microsoft.EntityFrameworkCore;

  /// <summary>Provides a simple API to set up the database.</summary>
  public sealed class DatabaseInitializer : IDatabaseInitializer
  {
    private readonly DbContext _dbContext;

    /// <summary>Initializes a new instance of the <see cref="BookApi.Data.DatabaseInitializer"/> class.</summary>
    /// <param name="dbContext">An object that represents a session with the database and can be used to query and save instances of your entities.</param>
    public DatabaseInitializer(DbContext dbContext)
    {
      _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    /// <summary>Sets up the database.</summary>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public Task SetUpAsync(CancellationToken cancellationToken) =>
      _dbContext.Database.EnsureCreatedAsync(cancellationToken);
  }
}
