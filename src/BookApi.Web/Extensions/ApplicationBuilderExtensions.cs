// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Microsoft.AspNetCore.Builder
{
  using Microsoft.EntityFrameworkCore;

  /// <summary>Extends the API of the <see cref="Microsoft.AspNetCore.Builder.WebApplication"/>.</summary>
  public static class ApplicationBuilderExtensions
  {
    public static WebApplication SetUpDatabase(this WebApplication app)
    {
      using (var scope = app.Services.CreateScope())
      {
        scope.ServiceProvider.GetRequiredService<DbContext>()
                             .Database.EnsureCreated();
      }

      return app;
    }
  }
}
