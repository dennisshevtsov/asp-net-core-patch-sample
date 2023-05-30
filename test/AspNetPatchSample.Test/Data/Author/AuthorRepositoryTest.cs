// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Author.Data.Test
{
  using Microsoft.Extensions.DependencyInjection;

  using AspNetPatchSampl.Data.Test;

  [TestClass]
  public sealed class AuthorRepositoryTest : DataTestBase
  {
#pragma warning disable CS8618
    private IAuthorRepository _authorRepository;
#pragma warning restore CS8618

    protected override void Initialize(IServiceProvider provider)
    {
      _authorRepository = provider.GetRequiredService<IAuthorRepository>();
    }

    [TestMethod]
    public async Task GetAsync_ExistingAuthorIdPassed_AuthorReturned()
    {
      var controlAuthorEntity = await TestAuthorEntity.AddAsync(DbContext);
      var actualAuthorEntity  = await _authorRepository.GetAsync(controlAuthorEntity, CancellationToken.None);

      Assert.IsNotNull(actualAuthorEntity);
      TestAuthorEntity.AreEqual(controlAuthorEntity, actualAuthorEntity);
    }

    [TestMethod]
    public async Task GetAsync_UknownAuthorIdPassed_NullReturned()
    {
      var controlAuthorIdentity = TestAuthorIdentity.New();
      var actualAuthorEntity    = await _authorRepository.GetAsync(controlAuthorIdentity, CancellationToken.None);

      Assert.IsNull(actualAuthorEntity);
    }

    [TestMethod]
    public async Task AddAsync_AuthorPassed_AuthorReturned()
    {
      var controlAuthorEntity = TestAuthorEntity.New();
      var actualAuthorEntity  = await _authorRepository.AddAsync(controlAuthorEntity, CancellationToken.None);

      Assert.IsNotNull(actualAuthorEntity);
      TestAuthorEntity.AreEqual(controlAuthorEntity, actualAuthorEntity);
    }

    [TestMethod]
    public async Task AddAsync_AuthorPassed_AuthorSaved()
    {
      var controlAuthorEntity = TestAuthorEntity.New();
      var addedAuthorEntity   = await _authorRepository.AddAsync(controlAuthorEntity, CancellationToken.None);
      var actualAuthorEntity  = await TestAuthorEntity.GetAsync(DbContext, addedAuthorEntity);

      Assert.IsNotNull(actualAuthorEntity);
      TestAuthorEntity.AreEqual(controlAuthorEntity, actualAuthorEntity);
    }

    [TestMethod]
    public async Task UpdateAsync_AuthorPassed_AuthorSaved()
    {
      var originalAuthorEntity = await TestAuthorEntity.AddAsync(DbContext);
      var newAuthorEntity      = TestAuthorEntity.New();
      var updatedProperties    = new[]
      {
        nameof(IAuthorEntity.Name),
      };

      await _authorRepository.UpdateAsync(originalAuthorEntity, newAuthorEntity, updatedProperties, CancellationToken.None);

      var actualAuthorEntity = await TestAuthorEntity.GetAsync(DbContext, originalAuthorEntity);

      Assert.IsNotNull(actualAuthorEntity);
      TestAuthorEntity.AreEqual(newAuthorEntity, actualAuthorEntity);
    }

    [TestMethod]
    public async Task DeleteAsync_ExistingAuthorPassed_AuthorDeleted()
    {
      var controlAuthorEntity = await TestAuthorEntity.AddAsync(DbContext);

      await _authorRepository.DeleteAsync(controlAuthorEntity, CancellationToken.None);

      var actualAuthorEntity = await TestAuthorEntity.GetAsync(DbContext, controlAuthorEntity);

      Assert.IsNull(actualAuthorEntity);
    }

    [TestMethod]
    public async Task DeleteAsync_UnknownAuthorPassed_ExistingAuthorKept()
    {
      var controlAuthorEntity   = await TestAuthorEntity.AddAsync(DbContext);
      var unknownAuthorIdentity = TestAuthorIdentity.New();

      await _authorRepository.DeleteAsync(unknownAuthorIdentity, CancellationToken.None);

      var actualAuthorEntity = await TestAuthorEntity.GetAsync(DbContext, controlAuthorEntity);

      Assert.IsNotNull(actualAuthorEntity);
    }
  }
}
