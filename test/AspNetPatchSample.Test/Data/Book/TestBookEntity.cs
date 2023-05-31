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

    public TestBookEntity(IBookEntity bookEntity) : this()
    {
      BookId = bookEntity.BookId;
      Title  = bookEntity.Title;
      Description = bookEntity.Description;
      Pages = bookEntity.Pages;
      Authors = bookEntity.Authors.Select(entity => new TestAuthorEntity(entity))
                                  .ToList();
    }

    public Guid BookId { get; set; }

    public string Title { get; }

    public string Description { get; }

    public int Pages { get; }

    public IEnumerable<IAuthorEntity> Authors { get; }
  }
}
