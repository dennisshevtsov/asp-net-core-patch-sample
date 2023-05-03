// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Book.Data
{
  using AspNetPatchSample.Author.Data;
  using AspNetPatchSample.Data;

  /// <summary>Represents a book entity.</summary>
  public sealed class BookEntity : EntityBase, IBookEntity
  {
    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Book.Data.BookEntity"/> class.</summary>
    public BookEntity()
    {
      Title = string.Empty;
      Description = string.Empty;
      Authors = new List<AuthorEntity>();
    }

    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Book.Data.BookEntity"/> class.</summary>
    /// <param name="bookEntity">An object that represents a book entity.</param>
    public BookEntity(IBookEntity bookEntity) : this()
    {
      Id = bookEntity.Id;
      Title = bookEntity.Title;
      Description = bookEntity.Description;
      Pages = bookEntity.Pages;
    }

    /// <summary>Gets an object that represents a title of a book.</summary>
    public string Title { get; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    public string Author
    {
      get
      {
        if (Authors == null)
        {
          return string.Empty;
        }

        var authors = Authors.Select(entity => entity.Name)
                             .ToArray();

        return string.Join(", ", authors);
      }
    }

    /// <summary>Gets an object that represents a description of a book.</summary>
    public string Description { get; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    public int Pages { get; }

    /// <summary>Gets an object that represents a collection of authors of this book.</summary>
    public IEnumerable<AuthorEntity> Authors { get; }
  }
}
