// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Book.App
{
  using AspNetPatchSample.App;
  using AspNetPatchSample.Author;

  /// <summary>Represents a book entity.</summary>
  public sealed class BookEntity : EntityBase, IBookEntity, IUpdatable<IBookEntity>
  {
    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Book.App.BookEntity"/> class.</summary>
    /// <param name="bookEntity">An object that represents a book entity.</param>
    public BookEntity(IBookEntity bookEntity) : base(bookEntity)
    {
      Title       = bookEntity.Title;
      Description = bookEntity.Description;
      Pages       = bookEntity.Pages;
      Authors     = bookEntity.Authors;
    }

    /// <summary>Gets/sets an object that represents a title of a book.</summary>
    public string Title { get; private set; }

    /// <summary>Gets/sets an object that represents a description of a book.</summary>
    public string Description { get; private set; }

    /// <summary>Gets/sets an object that represents a description of a book.</summary>
    public int Pages { get; private set; }

    /// <summary>Gets an object that represents a collection of authors of this book.</summary>
    public IEnumerable<IAuthorEntity> Authors { get; private set; }

    /// <summary>Updates this book.</summary>
    /// <param name="bookEntity">An object that represents a book entity from which this book should be updated..</param>
    /// <returns>A reference to this book.</returns>
    public IBookEntity Update(IBookEntity bookEntity) => (IBookEntity)base.Update(bookEntity);

    /// <summary>Updates this book.</summary>
    /// <param name="bookEntity">An object that represents a book entity from which this book should be updated..</param>
    /// <param name="properties">An object that represents a collection of properties to update.</param>
    /// <returns>A reference to this book.</returns>
    public IBookEntity Update(IBookEntity bookEntity, IEnumerable<string> properties) =>
      (IBookEntity)base.Update(bookEntity, properties);
  }
}
