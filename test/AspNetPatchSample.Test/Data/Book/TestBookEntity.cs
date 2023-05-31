// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Book.Data.Test
{
  using AspNetPatchSample.Author;
  using AspNetPatchSample.Author.Data.Test;

  public sealed class TestBookEntity : IBookEntity
  {
    public TestBookEntity()
    {
      Title       = string.Empty;
      Description = string.Empty;
      Authors     = new List<IAuthorEntity>();
    }

    public TestBookEntity(Guid bookId, string title, string description, int pages, IEnumerable<IAuthorEntity> authors) : this()
    {
      BookId      = bookId;
      Title       = title;
      Description = description;
      Pages       = pages;
      Authors     = authors.Select(entity => new TestAuthorEntity(entity))
                           .ToList();
    }

    public TestBookEntity(IBookEntity bookEntity)
      : this(bookEntity.BookId, bookEntity.Title, bookEntity.Description, bookEntity.Pages, bookEntity.Authors) { }

    public Guid BookId { get; set; }

    public string Title { get; }

    public string Description { get; }

    public int Pages { get; }

    public IEnumerable<IAuthorEntity> Authors { get; }
  }
}
