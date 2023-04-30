// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Book.App
{
  using AspNetPatchSample.App;

  /// <summary>Represents a book entity.</summary>
  public sealed class BookEntity : IBookEntity, IUpdatable<IBookEntity>, IPatchable
  {
    private string _title;
    private string _author;
    private string _description;

    private int _pages;

    private ISet<string> _properties;

    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Book.App.BookEntity"/> class.</summary>
    private BookEntity()
    {
      _title       = string.Empty;
      _author      = string.Empty;
      _description = string.Empty;

      _properties  = new HashSet<string>();
    }

    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Book.App.BookEntity"/> class.</summary>
    /// <param name="bookEntity">An object that represents a book entity.</param>
    public BookEntity(IBookEntity bookEntity) : this()
    {
      BookId      = bookEntity.BookId;
      Title       = bookEntity.Title;
      Author      = bookEntity.Author;
      Description = bookEntity.Description;
      Pages       = bookEntity.Pages;

      _properties.Clear();
    }

    /// <summary>Gets an object that represents an ID of a book.</summary>
    public Guid BookId { get; }

    /// <summary>Gets/sets an object that represents a title of a book.</summary>
    public string Title
    {
      get => _title;

      set
      {
        if (_title != value)
        {
          _title = value;
          _properties.Add(nameof(Title));
        }
      }
    }

    /// <summary>Gets/sets an object that represents a description of a book.</summary>
    public string Author
    {
      get => _author;

      set
      {
        if (_author != value)
        {
          _author = value;
          _properties.Add(nameof(Author));
        }
      }
    }

    /// <summary>Gets/sets an object that represents a description of a book.</summary>
    public string Description
    {
      get => _description;

      set
      {
        if (_description != value)
        {
          _description = value;
          _properties.Add(nameof(Description));
        }
      }
    }

    /// <summary>Gets/sets an object that represents a description of a book.</summary>
    public int Pages
    {
      get => _pages;

      set
      {
        if (_pages != value)
        {
          _pages = value;
          _properties.Add(nameof(Pages));
        }
      }
    }

    /// <summary>Gets an object that represents a collection of properties to update.</summary>
    public IEnumerable<string> Properties { get => _properties; }

    /// <summary>Converts this object to an instance of the <see cref="System.Guid"/>.</summary>
    /// <returns>An object that represents a Globally Unique Identifier.</returns>
    public Guid ToGuid() => BookId;

    /// <summary>Updates this book.</summary>
    /// <param name="bookEntity">An object that represents a book entity from which this book should be updated..</param>
    /// <returns>A reference to this book.</returns>
    public IBookEntity Update(IBookEntity bookEntity)
    {
      _properties.Clear();

      Title       = bookEntity.Title;
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
      _properties.Clear();

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
