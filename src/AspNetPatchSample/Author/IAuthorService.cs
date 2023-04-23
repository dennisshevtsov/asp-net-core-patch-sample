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
    public Task<IAuthorEntity?> GetAuthorAsync(
      IAuthorIdentity identity,
      CancellationToken cancellationToken);
  }
}
