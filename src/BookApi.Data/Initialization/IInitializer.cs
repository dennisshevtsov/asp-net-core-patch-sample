// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace BookApi.Data.Initialization
{
  /// <summary>Provides a simple API to set up the database.</summary>
  public interface IInitializer
  {
    public Task SetUpAsync(CancellationToken cancellationToken);
  }
}
