// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Author.Data.Test
{
  using Microsoft.EntityFrameworkCore;

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
      var testAuthorEntity = TestAuthorEntity.New();
      var dataAuthorEntity = new AuthorEntity(testAuthorEntity);

      var dataAuthorEntityEntry = dbContext.Add(dataAuthorEntity);
      await dbContext.SaveChangesAsync();
      dataAuthorEntityEntry.State = EntityState.Detached;

      return dataAuthorEntity;
    }

    public static async Task<List<IAuthorEntity>> AddAsync(DbContext dbContext, int authors)
    {
      var authorEntityCollection = new List<IAuthorEntity>();

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
      var controlList = control.OrderBy(entity => entity.AuthorId).ToList();
      var actualList  = actual.OrderBy(entity => entity.AuthorId).ToList();

      Assert.AreEqual(controlList.Count, actualList.Count);

      for (int i = 0; i < controlList.Count; i++)
      {
        TestAuthorEntity.AreEqual(controlList[i], actualList[i]);
      }
    }
  }
}
