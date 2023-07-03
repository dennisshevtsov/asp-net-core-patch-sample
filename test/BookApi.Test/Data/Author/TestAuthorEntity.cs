// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BookApi.Author.Data.Test;

public sealed class TestAuthorEntity : IAuthorEntity
{
  public TestAuthorEntity()
  {
    Name = string.Empty;
  }

  public TestAuthorEntity(IAuthorEntity authorEntity) : this()
  {
    AuthorId = authorEntity.AuthorId;
    Name     = authorEntity.Name;
  }

  public Guid AuthorId { get; private init; }

  public string Name { get; private init; }

  public static IAuthorEntity New() => new TestAuthorEntity
  {
    AuthorId = Guid.NewGuid(),
    Name     = Guid.NewGuid().ToString(),
  };

  public static async Task<IAuthorEntity> AddAsync(DbContext dbContext)
  {
    IAuthorEntity testAuthorEntity = TestAuthorEntity.New();
    AuthorEntity dataAuthorEntity  = new(testAuthorEntity);

    EntityEntry<AuthorEntity> dataAuthorEntityEntry = dbContext.Add(dataAuthorEntity);
    await dbContext.SaveChangesAsync();
    dataAuthorEntityEntry.State = EntityState.Detached;

    return dataAuthorEntity;
  }

  public static async Task<List<IAuthorEntity>> AddAsync(DbContext dbContext, int authors)
  {
    List<IAuthorEntity> authorEntityCollection = new();

    for (int i = 0; i < authors; i++)
    {
      authorEntityCollection.Add(await TestAuthorEntity.AddAsync(dbContext));
    }

    return authorEntityCollection;
  }

  public static async Task<IAuthorEntity?> GetAsync(DbContext dbContext, IAuthorIdentity authorIdentity)
    => await dbContext.Set<AuthorEntity>()
                      .AsNoTracking()
                      .Where(entity => entity.AuthorId == authorIdentity.AuthorId)
                      .SingleOrDefaultAsync();

  public static void AreEqual(IAuthorEntity control, IAuthorEntity actual)
  {
    Assert.AreEqual(control.Name, actual.Name);
  }

  public static void AreEqual(IEnumerable<IAuthorEntity> control, IEnumerable<IAuthorEntity> actual)
  {
    IList<IAuthorEntity> controlList = control.OrderBy(entity => entity.AuthorId).ToList();
    IList<IAuthorEntity> actualList  = actual.OrderBy(entity => entity.AuthorId).ToList();

    Assert.AreEqual(controlList.Count, actualList.Count);

    for (int i = 0; i < controlList.Count; i++)
    {
      TestAuthorEntity.AreEqual(controlList[i], actualList[i]);
    }
  }
}
