// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Microsoft.EntityFrameworkCore;

namespace Microsoft.AspNetCore.Builder;

/// <summary>Extends the API of the <see cref="Microsoft.AspNetCore.Builder.WebApplication"/>.</summary>
public static class ApplicationBuilderExtensions
{
  /// <summary>Sets up the database.</summary>
  /// <param name="app">An object that represents a web application used to configure the HTTP pipeline, and routes.</param>
  /// <returns>An object that represents a web application used to configure the HTTP pipeline, and routes.</returns>
  public static WebApplication SetUpDatabase(this WebApplication app)
  {
    using (IServiceScope scope = app.Services.CreateScope())
    {
      scope.ServiceProvider.GetRequiredService<DbContext>()
                           .Database.EnsureCreated();
    }

    return app;
  }
}
