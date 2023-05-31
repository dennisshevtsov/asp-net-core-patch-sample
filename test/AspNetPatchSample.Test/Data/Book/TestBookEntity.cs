// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Book.Data.Test
{
  using Microsoft.EntityFrameworkCore;

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

    public static IBookEntity New(int pages, IEnumerable<IAuthorEntity> authors) => new TestBookEntity
    {
      BookId      = Guid.NewGuid(),
      Title       = Guid.NewGuid().ToString(),
      Description = Guid.NewGuid().ToString(),
      Pages       = pages,
      Authors     = authors.Select(entity => new TestAuthorEntity(entity)).ToList(),
    };

    public static async Task<IBookEntity> AddAsync(DbContext dbContext)
    {
      var testBookEntity = TestBookEntity.New(500, new List<IAuthorEntity>());
      var dataBookEntity = new BookEntity(testBookEntity);

      var dataBookEntityEntry = dbContext.Add(dataBookEntity);
      await dbContext.SaveChangesAsync();
      dataBookEntityEntry.State = EntityState.Detached;

      return dataBookEntity;
    }

    public static async Task<IBookEntity?> GetAsync(DbContext dbContext, IBookIdentity bookIdentity)
      => await dbContext.Set<BookEntity>()
                        .AsNoTracking()
                        .Where(entity => entity.BookId == bookIdentity.BookId)
                        .SingleOrDefaultAsync();

    public static void AreEqual(IBookEntity control, IBookEntity actual)
    {
      Assert.AreEqual(control.Title, actual.Title);
      Assert.AreEqual(control.Description, actual.Description);
      Assert.AreEqual(control.Pages, actual.Pages);
      TestAuthorEntity.AreEqual(control.Authors, actual.Authors);
    }
  }
}
