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
      BookId      = bookEntity.BookId;
      Title       = bookEntity.Title;
      Description = bookEntity.Description;
      Pages       = bookEntity.Pages;
      Authors     = bookEntity.Authors.Select(entity => new TestAuthorEntity(entity))
                                      .ToList();
    }

    public Guid BookId { get; private init; }

    public string Title { get; private init; }

    public string Description { get; private init; }

    public int Pages { get; private init; }

    public IEnumerable<IAuthorEntity> Authors { get; private init; }
  }
}
