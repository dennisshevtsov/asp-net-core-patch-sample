// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Book.App
{
  /// <summary>Represents a book entity.</summary>
  public sealed class BookEntity : IBookEntity
  {
    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Book.App.BookEntity"/> class.</summary>
    /// <param name="bookData">An object that represents book data.</param>
    public BookEntity(IBookData bookData)
    {
      Name        = bookData.Name;
      Author      = bookData.Author;
      Description = bookData.Description;
      Pages       = bookData.Pages;
    }

    /// <summary>Gets an object that represents an ID of a book.</summary>
    public Guid BookId { get; }

    /// <summary>Gets an object that represents a name of a book.</summary>
    public string Name { get; private set; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    public string Author { get; private set; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    public string Description { get; private set; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    public int Pages { get; private set; }

    /// <summary>Converts this object to an instance of the <see cref="System.Guid"/>.</summary>
    /// <returns>An object that represents a Globally Unique Identifier.</returns>
    public Guid ToGuid() => BookId;

    /// <summary>Updates this book.</summary>
    /// <param name="bookData">An object that represents book data.</param>
    public void Update(IBookData bookData)
    {
      Name        = bookData.Name;
      Author      = bookData.Author;
      Description = bookData.Description;
      Pages       = bookData.Pages;
    }

    /// <summary>Updates this book.</summary>
    /// <param name="bookData">An object that represents book data.</param>
    /// <param name="properties">An object that represents a collection of properties to update.</param>
    public void Update(IBookData bookData, string[] properties)
    {
      for (int i = 0; i < properties.Length; ++i)
      {
        var property = typeof(IBookData).GetProperty(properties[i]);

        if (property != null)
        {
          var value = property.GetValue(bookData);

          property.SetValue(this, value);
        }
      }
    }
  }
}
