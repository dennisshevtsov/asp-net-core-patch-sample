// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Author.App
{
  using AspNetPatchSample.App;

  /// <summary>Provides a simple API to execute a task with an instance of the <see cref="AspNetPatchSample.Author.IAuthorEntity"/>.</summary>
  public sealed class AuthorService : ServiceBase<IAuthorIdentity, IAuthorData, IAuthorEntity, AuthorEntity>, IAuthorService
  {
    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Author.App.AuthorService"/> class.</summary>
    /// <param name="authorRepository">An object that provides a simple API to store instances of the <see cref="AspNetPatchSample.Author.IAuthorEntity"/>.</param>
    public AuthorService(IAuthorRepository authorRepository) : base(authorRepository) {}
  }
}
