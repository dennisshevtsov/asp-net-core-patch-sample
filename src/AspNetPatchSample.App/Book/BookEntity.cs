// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Book.App
{
  using AspNetPatchSample.App;

  /// <summary>Represents a book entity.</summary>
  public sealed class BookEntity : IBookEntity, IUpdatable<IBookEntity>, IPatchable
  {
    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Book.App.BookEntity"/> class.</summary>
    /// <param name="bookEntity">An object that represents a book entity.</param>
    public BookEntity(IBookEntity bookEntity)
    {
      Title       = bookEntity.Title;
      Author      = bookEntity.Author;
      Description = bookEntity.Description;
      Pages       = bookEntity.Pages;
      Properties  = Array.Empty<string>();
    }

    /// <summary>Gets an object that represents an ID of a book.</summary>
    public Guid BookId { get; }

    /// <summary>Gets an object that represents a title of a book.</summary>
    public string Title { get; private set; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    public string Author { get; private set; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    public string Description { get; private set; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    public int Pages { get; private set; }

    /// <summary>Gets an object that represents a collection of properties to update.</summary>
    public IEnumerable<string> Properties { get; private set; }

    /// <summary>Converts this object to an instance of the <see cref="System.Guid"/>.</summary>
    /// <returns>An object that represents a Globally Unique Identifier.</returns>
    public Guid ToGuid() => BookId;

    /// <summary>Updates this book.</summary>
    /// <param name="bookEntity">An object that represents a book entity from which this book should be updated..</param>
    /// <returns>A reference to this book.</returns>
    public IBookEntity Update(IBookEntity bookEntity)
    {
      Title        = bookEntity.Title;
      Author      = bookEntity.Author;
      Description = bookEntity.Description;
      Pages       = bookEntity.Pages;

      return this;
    }

    /// <summary>Updates this book.</summary>
    /// <param name="bookEntity">An object that represents a book entity from which this book should be updated..</param>
    /// <param name="properties">An object that represents a collection of properties to update.</param>
    /// <returns>A reference to this book.</returns>
    public IBookEntity Update(IBookEntity bookEntity, string[] properties)
    {
      if (properties.Contains(nameof(Title)))
      {
        Title = bookEntity.Title;
      }

      if (properties.Contains(nameof(Author)))
      {
        Author = bookEntity.Author;
      }

      if (properties.Contains(nameof(Description)))
      {
        Description = bookEntity.Description;
      }

      if (properties.Contains(nameof(Pages)))
      {
        Pages = bookEntity.Pages;
      }

      return this;
    }
  }
}
