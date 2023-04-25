// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Book.App
{
  using System;

  /// <summary>Represents a simple API to operate instances of the <see cref="AspNetPatchSample.Domain.Book.IBookEntity"/>.</summary>
  public sealed class BookService : IBookService
  {
    private readonly IBookRepository _bookRepository;

    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Domain.Book.BookService"/> class.</summary>
    /// <param name="bookRepository">An object that provides a simple API to store instances of the <see cref="IBookEntity"/>.</param>
    public BookService(IBookRepository bookRepository)
    {
      _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
    }

    /// <summary>Gets a book.</summary>
    /// <param name="bookIdentity">An object that represents a book identity.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="IBookEntity"/>. The result can be null.</returns>
    public Task<IBookEntity?> GetAsync(IBookIdentity bookIdentity, CancellationToken cancellationToken)
      => _bookRepository.GetAsync(bookIdentity, cancellationToken);

    /// <summary>Adds a book.</summary>
    /// <param name="bookData">An object that reprents book data to add.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="IBookEntity"/>.</returns>
    public Task<IBookEntity> AddAsync(IBookData bookData, CancellationToken cancellationToken)
      => _bookRepository.AddAsync(new BookEntity(bookData), cancellationToken);

    /// <summary>Updates a book.</summary>
    /// <param name="originalBookEntity">An object that reprents a book entity to update.</param>
    /// <param name="newBookEntity">An object that reprents a book entity from whick an original one should be updated.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public async Task UpdateAsync(IBookEntity originalBookEntity, IBookEntity newBookEntity, CancellationToken cancellationToken)
    {
      var dbBookEntity = await _bookRepository.GetAsync(originalBookEntity, cancellationToken);

      if (dbBookEntity == null)
      {
        return;
      }

      var businessBookEntity = new BookEntity(dbBookEntity);
      businessBookEntity.Update(originalBookEntity);

      await _bookRepository.UpdateAsync(
        businessBookEntity, Array.Empty<string>(), cancellationToken);
    }

    /// <summary>Updates a book.</summary>
    /// <param name="originalBookEntity">An object that reprents a book entity to update.</param>
    /// <param name="newBookEntity">An object that reprents a book entity from whick an original one should be updated.</param>
    /// <param name="properties">An object that represents a collection of properties to update.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public async Task UpdateAsync(IBookEntity originalBookEntity, IBookEntity newBookEntity, string[] properties, CancellationToken cancellationToken)
    {
      var dbBookEntity = await _bookRepository.GetAsync(originalBookEntity, cancellationToken);

      if (dbBookEntity == null)
      {
        return;
      }

      var businessBookEntity = new BookEntity(dbBookEntity);
      businessBookEntity.Update(originalBookEntity, properties);

      await _bookRepository.UpdateAsync(businessBookEntity, properties, cancellationToken);
    }
  }
}
