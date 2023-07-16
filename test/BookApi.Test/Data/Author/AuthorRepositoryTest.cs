// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Microsoft.Extensions.DependencyInjection;

using BookApi.Data.Test;

namespace BookApi.Author.Data.Test;

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
    // Arrange
    IAuthorEntity controlAuthorEntity = await TestAuthorEntity.AddAsync(DbContext);

    // Act
    IAuthorEntity? actualAuthorEntity = await _authorRepository.GetAsync(controlAuthorEntity, Array.Empty<string>(), CancellationToken.None);

    // Assert
    Assert.IsNotNull(actualAuthorEntity);
    TestAuthorEntity.AreEqual(controlAuthorEntity, actualAuthorEntity);
  }

  [TestMethod]
  public async Task GetAsync_UknownAuthorIdPassed_NullReturned()
  {
    // Arrange
    IAuthorIdentity controlAuthorIdentity = TestAuthorIdentity.New();

    // Act
    IAuthorEntity? actualAuthorEntity = await _authorRepository.GetAsync(controlAuthorIdentity, Array.Empty<string>(), CancellationToken.None);

    // Assert
    Assert.IsNull(actualAuthorEntity);
  }

  [TestMethod]
  public async Task AddAsync_AuthorPassed_AuthorReturned()
  {
    // Arrange
    IAuthorEntity controlAuthorEntity = TestAuthorEntity.New();

    // Act
    IAuthorEntity actualAuthorEntity = await _authorRepository.AddAsync(controlAuthorEntity, CancellationToken.None);

    // Assert
    Assert.IsNotNull(actualAuthorEntity);
    TestAuthorEntity.AreEqual(controlAuthorEntity, actualAuthorEntity);
  }

  [TestMethod]
  public async Task AddAsync_AuthorPassed_AuthorSaved()
  {
    // Arrange
    IAuthorEntity controlAuthorEntity = TestAuthorEntity.New();

    // Act
    IAuthorEntity addedAuthorEntity = await _authorRepository.AddAsync(controlAuthorEntity, CancellationToken.None);
    IAuthorEntity? actualAuthorEntity = await TestAuthorEntity.GetAsync(DbContext, addedAuthorEntity);

    // Assert
    Assert.IsNotNull(actualAuthorEntity);
    TestAuthorEntity.AreEqual(controlAuthorEntity, actualAuthorEntity);
  }

  [TestMethod]
  public async Task UpdateAsync_AuthorPassed_AuthorSaved()
  {
    // Arrange
    IAuthorEntity originalAuthorEntity = await TestAuthorEntity.AddAsync(DbContext);
    IAuthorEntity newAuthorEntity      = TestAuthorEntity.New();

    string[] updatedProperties = new[]
    {
      nameof(IAuthorEntity.Name),
    };

    // Act
    await _authorRepository.UpdateAsync(originalAuthorEntity, newAuthorEntity, updatedProperties, CancellationToken.None);

    // Assert
    IAuthorEntity? actualAuthorEntity = await TestAuthorEntity.GetAsync(DbContext, originalAuthorEntity);

    Assert.IsNotNull(actualAuthorEntity);
    TestAuthorEntity.AreEqual(newAuthorEntity, actualAuthorEntity);
  }

  [TestMethod]
  public async Task DeleteAsync_ExistingAuthorPassed_AuthorDeleted()
  {
    // Arrange
    IAuthorEntity controlAuthorEntity = await TestAuthorEntity.AddAsync(DbContext);

    // Act
    await _authorRepository.DeleteAsync(controlAuthorEntity, CancellationToken.None);

    // Assert
    var actualAuthorEntity = await TestAuthorEntity.GetAsync(DbContext, controlAuthorEntity);
    Assert.IsNull(actualAuthorEntity);
  }

  [TestMethod]
  public async Task DeleteAsync_UnknownAuthorPassed_ExistingAuthorKept()
  {
    // Arrange
    IAuthorEntity controlAuthorEntity = await TestAuthorEntity.AddAsync(DbContext);
    IAuthorIdentity unknownAuthorIdentity = TestAuthorIdentity.New();

    // Act
    await _authorRepository.DeleteAsync(unknownAuthorIdentity, CancellationToken.None);

    // Assert
    IAuthorEntity? actualAuthorEntity = await TestAuthorEntity.GetAsync(DbContext, controlAuthorEntity);
    Assert.IsNotNull(actualAuthorEntity);
  }
}
