// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Application.Service
{
    using System;

    using AspNetPatchSample.Application.Entity;
    using AspNetPatchSample.Domain.Book;

    /// <summary>Represents a simple API to operate instances of the <see cref="Domain.Book.IBookEntity"/>.</summary>
    public sealed class BookService : IBookService
  {
    private readonly IBookRepository _bookRepository;

        /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Application.Service.BookService"/> class.</summary>
        /// <param name="bookRepository">An object that provides a simple API to store instances of the <see cref="Domain.Book.IBookEntity"/>.</param>
        public BookService(IBookRepository bookRepository)
    {
      _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
    }

        /// <summary>Gets a book.</summary>
        /// <param name="bookIdentity">An object that represents a book identity.</param>
        /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
        /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="Domain.Book.IBookEntity"/>. The result can be null.</returns>
        public Task<IBookEntity?> GetBookAsync(IBookIdentity bookIdentity, CancellationToken cancellationToken)
      => _bookRepository.GetAsync(bookIdentity, cancellationToken);

        /// <summary>Adds a book.</summary>
        /// <param name="bookData">An object that reprents book data.</param>
        /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
        /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="Domain.Book.IBookEntity"/>.</returns>
        public Task<IBookEntity> AddBookAsync(IBookData bookData, CancellationToken cancellationToken)
      => _bookRepository.AddAsync(new BookEntity(bookData), cancellationToken);

        /// <summary>Updates a book.</summary>
        /// <param name="bookEntity">An object that reprents a book entity.</param>
        /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
        /// <returns>An object that represents an asynchronous operation. The result is an instance of the <see cref="Domain.Book.IBookEntity"/>.</returns>
        public async Task<IBookEntity?> UpdateBookAsync(IBookEntity bookEntity, CancellationToken cancellationToken)
    {
      var dbBookEntity = await _bookRepository.GetAsync(bookEntity, cancellationToken);

      if (dbBookEntity == null)
      {
        return null;
      }

      var businessBookEntity = new BookEntity(dbBookEntity);
      businessBookEntity.Update(bookEntity);

      await _bookRepository.UpdateAsync(
        businessBookEntity, Array.Empty<string>(), cancellationToken);

      return businessBookEntity;
    }

        /// <summary>Updates a book.</summary>
        /// <param name="bookEntity">An object that represents a book entity.</param>
        /// <param name="properties">An object that represents a collection of properties to update.</param>
        /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
        /// <returns>An object that represents an asynchronous operation. The result is an instance of the <see cref="Domain.Book.IBookEntity"/>.</returns>
        public async Task<IBookEntity?> UpdateBookAsync(IBookEntity bookEntity, string[] properties, CancellationToken cancellationToken)
    {
      var dbBookEntity = await _bookRepository.GetAsync(bookEntity, cancellationToken);

      if (dbBookEntity == null)
      {
        return null;
      }

      var businessBookEntity = new BookEntity(dbBookEntity);
      businessBookEntity.Update(bookEntity, properties);

      await _bookRepository.UpdateAsync(businessBookEntity, properties, cancellationToken);

      return businessBookEntity;
    }
  }
}
