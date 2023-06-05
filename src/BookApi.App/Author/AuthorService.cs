// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace BookApi.Author.App
{
  using BookApi.App;

  /// <summary>Provides a simple API to execute a task with an instance of the <see cref="BookApi.Author.IAuthorEntity"/>.</summary>
  public sealed class AuthorService : ServiceBase<AuthorEntity, IAuthorEntity, IAuthorIdentity>, IAuthorService
  {
    /// <summary>Initializes a new instance of the <see cref="BookApi.Author.App.AuthorService"/> class.</summary>
    /// <param name="authorRepository">An object that provides a simple API to store instances of the <see cref="BookApi.Author.IAuthorEntity"/>.</param>
    public AuthorService(IAuthorRepository authorRepository) : base(authorRepository) { }
  }
}
