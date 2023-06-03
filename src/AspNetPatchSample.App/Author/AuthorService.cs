// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Author.App
{
  using AspNetPatchSample.App;
  using System.Collections.Generic;
  using System.Threading;
  using System.Threading.Tasks;

  /// <summary>Provides a simple API to execute a task with an instance of the <see cref="AspNetPatchSample.Author.IAuthorEntity"/>.</summary>
  public sealed class AuthorService : ServiceBase<IAuthorEntity, IAuthorIdentity>, IAuthorService
  {
    private readonly IAuthorRepository _authorRepository;

    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.Author.App.AuthorService"/> class.</summary>
    /// <param name="authorRepository">An object that provides a simple API to store instances of the <see cref="AspNetPatchSample.Author.IAuthorEntity"/>.</param>
    public AuthorService(IAuthorRepository authorRepository) : base(authorRepository)
    {
      _authorRepository = authorRepository;
    }

    public override Task UpdateAsync(IAuthorEntity originalEntity, IAuthorEntity newEntity, CancellationToken cancellationToken)
    {
      var properties = new[]
      {
        nameof(IAuthorEntity.Name),
      };

      return _authorRepository.UpdateAsync(originalEntity, newEntity, properties, cancellationToken);
    }
  }
}
