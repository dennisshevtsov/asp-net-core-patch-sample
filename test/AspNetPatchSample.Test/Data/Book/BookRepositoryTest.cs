// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Book.Data.Test
{
  using Microsoft.Extensions.DependencyInjection;

  using AspNetPatchSampl.Data.Test;
  using AspNetPatchSample.Author.Data.Test;
  using AspNetPatchSample.Author;
  using AspNetPatchSample.Author.Data;

  [TestClass]
  public sealed class BookRepositoryTest : DataTestBase
  {
#pragma warning disable CS8618
    private IBookRepository _bookRepository;
#pragma warning restore CS8618

    protected override void Initialize(IServiceProvider provider)
    {
      _bookRepository = provider.GetRequiredService<IBookRepository>();
    }

    [TestMethod]
    public async Task GetAsync_ExistingBookIdPassed_BookReturned()
    {
      var controlBookEntity = await TestBookEntity.AddAsync(DbContext);
      var actualBookEntity  = await _bookRepository.GetAsync(controlBookEntity, CancellationToken.None);

      Assert.IsNotNull(actualBookEntity);
      TestBookEntity.AreEqual(controlBookEntity, actualBookEntity);
    }

    [TestMethod]
    public async Task GetAsync_UknownBookIdPassed_NullReturned()
    {
      var controlBookIdentity = TestBookIdentity.New();
      var actualBookEntity = await _bookRepository.GetAsync(controlBookIdentity, CancellationToken.None);

      Assert.IsNull(actualBookEntity);
    }

    [TestMethod]
    public async Task AddAsync_BookPassed_BookReturned()
    {
      var controlBookEntity = TestBookEntity.New();
      var actualBookEntity = await _bookRepository.AddAsync(controlBookEntity, CancellationToken.None);

      Assert.IsNotNull(actualBookEntity);
      TestBookEntity.AreEqual(controlBookEntity, actualBookEntity);
    }

    [TestMethod]
    public async Task AddAsync_BookPassed_BookSaved()
    {
      var controlBookEntity = TestBookEntity.New();
      var addedBookEntity = await _bookRepository.AddAsync(controlBookEntity, CancellationToken.None);
      var actualBookEntity = await TestBookEntity.GetAsync(DbContext, addedBookEntity);

      Assert.IsNotNull(actualBookEntity);
      TestBookEntity.AreEqual(controlBookEntity, actualBookEntity);
    }

    [TestMethod]
    public async Task UpdateAsync_BookPassed_BookSaved()
    {
      var originalBookEntity = await TestBookEntity.AddAsync(DbContext);
      var newBookEntity = TestBookEntity.New();
      var updatedProperties = new[]
      {
        nameof(IBookEntity.Title),
        nameof(IBookEntity.Description),
        nameof(IBookEntity.Pages),
      };

      await _bookRepository.UpdateAsync(originalBookEntity, newBookEntity, updatedProperties, CancellationToken.None);

      var actualBookEntity = await TestBookEntity.GetAsync(DbContext, originalBookEntity);

      Assert.IsNotNull(actualBookEntity);
      TestBookEntity.AreEqual(newBookEntity, actualBookEntity);
    }

    [TestMethod]
    public async Task DeleteAsync_ExistingBookPassed_BookDeleted()
    {
      var controlBookEntity = await TestBookEntity.AddAsync(DbContext);

      await _bookRepository.DeleteAsync(controlBookEntity, CancellationToken.None);

      var actualBookEntity = await TestBookEntity.GetAsync(DbContext, controlBookEntity);

      Assert.IsNull(actualBookEntity);
    }
  }
}
