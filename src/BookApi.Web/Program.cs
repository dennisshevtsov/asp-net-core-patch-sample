// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.SetUpControllers();

builder.Services.SetUpApplication();
builder.Services.SetUpInfrastructure(builder.Configuration);

WebApplication app = builder.Build();

app.SetUpDatabase();
app.UseSwagger();
app.UseRouting();
app.MapControllers();

app.Run();
