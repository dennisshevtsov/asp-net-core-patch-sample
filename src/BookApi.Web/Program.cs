// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using BookApi.Web.Binding;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddControllers(options => options.ModelBinderProviders.Insert(0, new RequestDtoBinderProvider()));

builder.Services.SetUpApplication();
builder.Services.SetUpInfrastructure(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
  scope.ServiceProvider.GetRequiredService<DbContext>().Database.EnsureCreated();
}

app.UseSwagger();
app.UseRouting();
app.MapControllers();

app.Run();
