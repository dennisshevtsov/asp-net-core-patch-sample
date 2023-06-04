// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Book.App
{
  using System.Threading;
  using System.Threading.Tasks;

  using AspNetPatchSample.App;

  /// <summary>Represents a simple API to operate instances of the <see cref="AspNetPatchSample.Book.IBookEntity"/>.</summary>
  public sealed class BookService : ServiceBase<IBookEntity, IBookIdentity>, IBookService
  {
    private readonly IBookRepository _bookRepository;

    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Book.App.BookService"/> class.</summary>
    /// <param name="bookRepository">An object that provides a simple API to store instances of the <see cref="AspNetPatchSample.Book.IBookEntity"/>.</param>
    public BookService(IBookRepository bookRepository) : base(bookRepository)
    {
      _bookRepository = bookRepository;
    }

    public override Task UpdateAsync(IBookEntity originalEntity, IBookEntity newEntity, CancellationToken cancellationToken)
    {
      var properties = new[]
      {
        nameof(IBookEntity.Title),
        nameof(IBookEntity.Description),
        nameof(IBookEntity.Pages),
        nameof(IBookEntity.Authors),
      };

      return _bookRepository.UpdateAsync(originalEntity, newEntity, properties, cancellationToken);
    }
  }
}
