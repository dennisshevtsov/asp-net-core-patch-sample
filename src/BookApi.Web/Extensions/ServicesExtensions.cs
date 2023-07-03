// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using BookApi.Web.Binding;
using BookApi.Web.Filters;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>Extends the API of the <see cref="Microsoft.Extensions.DependencyInjection.IServiceCollection"/>.</summary>
public static class ServicesExtensions
{
  /// <summary>Sets up controllers.</summary>
  /// <param name="services">An object that specifies the contract for a collection of service descriptors.</param>
  /// <returns>An object that specifies the contract for a collection of service descriptors.</returns>
  public static IServiceCollection SetUpControllers(this IServiceCollection services)
  {
    services.AddControllers(options =>
    {
      options.Filters.Insert(0, new SuppressValidationFilter());
      options.ModelBinderProviders.Insert(0, new RequestDtoBinderProvider());
    });

    return services;
  }
}
