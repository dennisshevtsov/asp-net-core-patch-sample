// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Microsoft.Extensions.DependencyInjection
{
  using AspNetPatchSample.Author;
  using AspNetPatchSample.Book;

  using AspNetPatchSample.Author.Infrastructure;
  using AspNetPatchSample.Book.Infrastructure;

  /// <summary>Extends the API of the <see cref="Microsoft.Extensions.DependencyInjection.IServiceCollection"/>.</summary>
  public static class RepositoryExtensions
  {
    /// <summary>Registers repositories in a DI container.</summary>
    /// <param name="services">An object that specifies the contract for a collection of service descriptors.</param>
    /// <returns>An object that specifies the contract for a collection of service descriptors.</returns>
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
      services.AddScoped<IAuthorRepository, AuthorRepository>();
      services.AddScoped<IBookRepository, BookRepository>();

      return services;
    }
  }
}
