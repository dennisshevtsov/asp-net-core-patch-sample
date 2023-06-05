// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace BookApi.Data
{
  /// <summary>Provides a simple API to set up the database.</summary>
  public interface IDatabaseInitializer
  {
    /// <summary>Sets up the database.</summary>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public Task SetUpAsync(CancellationToken cancellationToken);
  }
}
