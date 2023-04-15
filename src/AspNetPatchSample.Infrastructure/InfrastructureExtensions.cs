﻿// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Microsoft.Extensions.DependencyInjection
{
  using Microsoft.EntityFrameworkCore;

  using AspNetPatchSample.Infrastructure;

  /// <summary>Extends the API of the <see cref="Microsoft.Extensions.DependencyInjection.IServiceCollection"/>.</summary>
  public static class InfrastructureExtensions
  {
    public static IServiceCollection SetUpInfrastructure(this IServiceCollection services)
    {
      services.AddRepositories();
      services.AddDbContext<DbContext, AppDbContext>();

      return services;
    }
  }
}