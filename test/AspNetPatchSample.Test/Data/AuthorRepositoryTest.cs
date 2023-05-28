// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Test.Data
{
  using Microsoft.Extensions.DependencyInjection;

  using AspNetPatchSample.Author;
  using AspNetPatchSample.Author.Data.Test;

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
      var actualAuthorEntity = await _authorRepository.GetAsync(controlAuthorEntity, CancellationToken.None);

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
  }
}
