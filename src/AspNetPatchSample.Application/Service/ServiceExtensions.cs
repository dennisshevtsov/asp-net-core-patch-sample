// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Microsoft.Extensions.DependencyInjection
{
  using AspNetPatchSample.Application.Service;
  using AspNetPatchSample.Domain.Service;

  /// <summary>Extends the API of the <see cref="Microsoft.Extensions.DependencyInjection.IServiceCollection"/>.</summary>
  public static class ServiceExtensions
  {
    /// <summary>Registers services in a DI container.</summary>
    /// <param name="services">An object that specifies the contract for a collection of service descriptors.</param>
    /// <returns>An object that specifies the contract for a collection of service descriptors.</returns>
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
      services.AddScoped<IBookService, BookService>();

      return services;
    }
  }
}
