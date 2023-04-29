// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Microsoft.Extensions.DependencyInjection
{
  using Microsoft.EntityFrameworkCore;

  using AspNetPatchSample.Data;

  /// <summary>Extends the API of the <see cref="Microsoft.Extensions.DependencyInjection.IServiceCollection"/>.</summary>
  public static class InfrastructureExtensions
  {
    /// <summary>Sets up the infrastructure.</summary>
    /// <param name="services">An object that specifies the contract for a collection of service descriptors.</param>
    /// <returns>An object that specifies the contract for a collection of service descriptors.</returns>
    public static IServiceCollection SetUpInfrastructure(this IServiceCollection services)
    {
      services.AddRepositories();
      services.AddDbContext<DbContext, AppDbContext>();

      return services;
    }
  }
}
