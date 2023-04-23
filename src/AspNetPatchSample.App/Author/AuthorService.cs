// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Author.App
{
  /// <summary>Provides a simple API to execute a task with an instance of the <see cref="AspNetPatchSample.Author.IAuthorEntity"/>.</summary>
  public sealed class AuthorService : IAuthorService
  {
    private readonly IAuthorRepository _authorRepository;

    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Author.App.AuthorService"/> class.</summary>
    /// <param name="authorRepository">An object that provides a simple API to store instances of the <see cref="AspNetPatchSample.Author.IAuthorEntity"/>.</param>
    public AuthorService(IAuthorRepository authorRepository)
    {
      _authorRepository = authorRepository ?? throw new ArgumentNullException(nameof(authorRepository));
    }

    /// <summary>Gets a new author.</summary>
    /// <param name="identity">An object that represents an author identity to get.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="AspNetPatchSample.Author.IAuthorEntity"/>. The result can be null.</returns>
    public Task<IAuthorEntity?> GetAuthorAsync(
      IAuthorIdentity identity,
      CancellationToken cancellationToken)
      => _authorRepository.GetAsync(identity, cancellationToken);

    /// <summary>Adds a new author.</summary>
    /// <param name="authorData">An object that represents author data from that a new author should be created.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="AspNetPatchSample.Author.IAuthorEntity"/>.</returns>
    public Task<IAuthorEntity> AddAuthorAsync(
      IAuthorData authorData,
      CancellationToken cancellationToken)
      => _authorRepository.AddAsync(new AuthorEntity(authorData), cancellationToken);

    /// <summary>Updates an author.</summary>
    /// <param name="originalAuthorEntity">An object that represents an author entity to update.</param>
    /// <param name="newAuthorEntity">An object that represents an author entity from that the original one should be updated.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public Task UpdateAuthorAsync(
      IAuthorEntity originalAuthorEntity,
      IAuthorEntity newAuthorEntity,
      CancellationToken cancellationToken)
      => _authorRepository.UpdateAsync(
        new AuthorEntity(originalAuthorEntity).Update(newAuthorEntity),
        Array.Empty<string>(),
        cancellationToken);

    /// <summary>Updates an author partially.</summary>
    /// <param name="originalAuthorEntity">An object that represents an author entity to update.</param>
    /// <param name="newAuthorEntity">An object that represents an author entity from that the original one should be updated.</param>
    /// <param name="properties">An object that represents a collection of properties to update.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public Task UpdateAuthorAsync(
      IAuthorEntity originalAuthorEntity,
      IAuthorEntity newAuthorEntity,
      string[] properties,
      CancellationToken cancellationToken)
      => _authorRepository.UpdateAsync(
        new AuthorEntity(originalAuthorEntity).Update(newAuthorEntity),
        properties,
        cancellationToken);

    /// <summary>Deletes an author.</summary>
    /// <param name="identity">An object that represents an author identity to delete.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public Task DeleteAuthorAsync(
      IAuthorIdentity identity,
      CancellationToken cancellationToken)
      => _authorRepository.DeleteAsync(identity, cancellationToken);
  }
}
