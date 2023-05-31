// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Book.Data.Test
{
  using Microsoft.Extensions.DependencyInjection;

  using AspNetPatchSampl.Data.Test;
  using AspNetPatchSample.Author.Data.Test;

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
  }
}
