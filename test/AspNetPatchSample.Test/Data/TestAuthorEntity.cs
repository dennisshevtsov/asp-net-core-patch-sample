// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Test.Data
{
  using AspNetPatchSample.Author;
  using AspNetPatchSample.Author.Data;

  using Microsoft.EntityFrameworkCore;

  public sealed class TestAuthorEntity : IAuthorEntity
  {
    public TestAuthorEntity()
    {
      Name = string.Empty;
    }

    public TestAuthorEntity(Guid authorId, string name) : this()
    {
      AuthorId = authorId;
      Name     = name;
    }

    public Guid AuthorId { get; }

    public string Name { get; }

    public static IAuthorEntity New() =>
      new TestAuthorEntity(Guid.NewGuid(), Guid.NewGuid().ToString());

    public static async Task<IAuthorEntity> AddAsync(DbContext dbContext)
    {
      var testAuthorEntity = TestAuthorEntity.New();
      var dataAuthorEntity = new AuthorEntity(testAuthorEntity);

      var dataAuthorEntityEntry = dbContext.Add(dataAuthorEntity);
      await dbContext.SaveChangesAsync();
      dataAuthorEntityEntry.State = EntityState.Detached;

      return dataAuthorEntity;
    }

    public static void AreEqual(IAuthorEntity control, IAuthorEntity actual)
    {
      Assert.AreEqual(control.AuthorId, actual.AuthorId);
      Assert.AreEqual(control.Name    , actual.Name    );
    }
  }
}
