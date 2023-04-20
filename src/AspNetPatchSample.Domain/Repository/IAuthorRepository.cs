// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Domain.Repository
{
  using AspNetPatchSample.Domain.Entity;

  /// <summary>Provides a simple API to store instances of the <see cref="AspNetPatchSample.Domain.Entity.IAuthorEntity"/>.</summary>
  public interface IAuthorRepository: IRepository<IAuthorEntity>
  {
    /// <summary>Gets an author by an ID of this entity.</summary>
    /// <param name="identity">An object that represents an author identity.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="AspNetPatchSample.Domain.Entity.IAuthorEntity"/>.</returns>
    public Task<IAuthorEntity?> GetAsync(IAuthorIdentity identity, CancellationToken cancellationToken);
  }
}
