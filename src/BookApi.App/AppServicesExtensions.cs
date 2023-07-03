// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using BookApi.Author;
using BookApi.Author.App;
using BookApi.Book;
using BookApi.Book.App;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>Extends the API of the <see cref="Microsoft.Extensions.DependencyInjection.IServiceCollection"/>.</summary>
public static class AppServicesExtensions
{
  /// <summary>Sets up the app.</summary>
  /// <param name="services">An object that specifies the contract for a collection of service descriptors.</param>
  /// <returns>An object that specifies the contract for a collection of service descriptors.</returns>
  public static IServiceCollection SetUpApplication(this IServiceCollection services)
  {
    services.AddServices();

    return services;
  }

  /// <summary>Registers services in a DI container.</summary>
  /// <param name="services">An object that specifies the contract for a collection of service descriptors.</param>
  /// <returns>An object that specifies the contract for a collection of service descriptors.</returns>
  public static IServiceCollection AddServices(this IServiceCollection services)
  {
    services.AddScoped<IAuthorService, AuthorService>();
    services.AddScoped<IBookService, BookService>();

    return services;
  }
}
