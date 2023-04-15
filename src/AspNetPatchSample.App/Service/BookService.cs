// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.App.Service
{
  using System;

  using AspNetPatchSample.Domain.Entity;
  using AspNetPatchSample.Domain.Repository;
  using AspNetPatchSample.Domain.Service;

  /// <summary>Represents a simple API to operate instances of the <see cref="AspNetPatchSample.Domain.Entity.IBookEntity"/>.</summary>
  public sealed class BookService : IBookService
  {
    private readonly IBookRepository _bookRepository;

    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.App.Service.BookService"/> class.</summary>
    /// <param name="bookRepository">An object that provides a simple API to store instances of the <see cref="AspNetPatchSample.Domain.Entity.IBookEntity"/>.</param>
    public BookService(IBookRepository bookRepository)
    {
      _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
    }

    /// <summary>Gets a book.</summary>
    /// <param name="bookIdentity">An object that represents a book identity.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="AspNetPatchSample.Domain.Entity.IBookEntity"/>. The result can be null.</returns>
    public Task<IBookEntity?> GetBookAsync(IBookIdentity bookIdentity, CancellationToken cancellationToken)
      => _bookRepository.GetBookAsync(bookIdentity, cancellationToken);

    /// <summary>Adds a book.</summary>
    /// <param name="bookData">An object that reprents book data.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="AspNetPatchSample.Domain.Entity.IBookEntity"/>.</returns>
    public Task<IBookEntity> AddBookAsync(IBookData bookData, CancellationToken cancellationToken)
      => _bookRepository.AddBookAsync(bookData, cancellationToken);

    /// <summary>Updates a book.</summary>
    /// <param name="bookEntity">An object that reprents a book entity.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public Task UpdateBookAsync(IBookEntity bookEntity, CancellationToken cancellationToken)
      => _bookRepository.UpdateBookAsync(bookEntity, cancellationToken);

    /// <summary>Updates a book.</summary>
    /// <param name="bookEntity">An object that represents a book entity.</param>
    /// <param name="properties">An object that represents a collection of properties to update.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation.</returns>
    public Task UpdateBookAsync(IBookEntity bookEntity, string[] properties, CancellationToken cancellationToken)
      => _bookRepository.UpdateBookAsync(bookEntity, properties, cancellationToken);
  }
}
