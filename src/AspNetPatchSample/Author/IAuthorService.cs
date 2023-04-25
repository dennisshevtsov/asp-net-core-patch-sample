// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Author
{
  /// <summary>Provides a simple API to execute a task with an instance of the <see cref="AspNetPatchSample.Author.IAuthorEntity"/>.</summary>
  public interface IAuthorService
  {
    /// <summary>Gets a new author.</summary>
    /// <param name="identity">An object that represents an author identity to get.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="AspNetPatchSample.Author.IAuthorEntity"/>. The result can be null.</returns>
    public Task<IAuthorEntity?> GetAsync(
      IAuthorIdentity identity,
      CancellationToken cancellationToken);

    /// <summary>Adds a new author.</summary>
    /// <param name="authorData">An object that represents author data from that a new author should be created.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="AspNetPatchSample.Author.IAuthorEntity"/>.</returns>
    public Task<IAuthorEntity> AddAsync(
      IAuthorData authorData,
      CancellationToken cancellationToken);

    /// <summary>Updates an author.</summary>
    /// <param name="originalAuthorEntity">An object that represents an author entity to update.</param>
    /// <param name="newAuthorEntity">An object that represents an author entity from that the original one should be updated.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public Task UpdateAsync(
      IAuthorEntity originalAuthorEntity,
      IAuthorEntity newAuthorEntity,
      CancellationToken cancellationToken);

    /// <summary>Updates an author partially.</summary>
    /// <param name="originalAuthorEntity">An object that represents an author entity to update.</param>
    /// <param name="newAuthorEntity">An object that represents an author entity from that the original one should be updated.</param>
    /// <param name="properties">An object that represents a collection of properties to update.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public Task UpdateAsync(
      IAuthorEntity originalAuthorEntity,
      IAuthorEntity newAuthorEntity,
      string[] properties,
      CancellationToken cancellationToken);

    /// <summary>Deletes an author.</summary>
    /// <param name="identity">An object that represents an author identity to delete.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public Task DeleteAsync(
      IAuthorIdentity identity,
      CancellationToken cancellationToken);
  }
}
