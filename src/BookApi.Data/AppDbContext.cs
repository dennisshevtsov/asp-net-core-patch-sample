// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace BookApi.Data
{
  using Microsoft.EntityFrameworkCore;

  using BookApi.Author.Data;
  using BookApi.Book.Data;

  /// <summary>Represents a session with the database and can be used to query and save instances of your entities.</summary>
  public sealed class AppDbContext : DbContext
  {
    /// <summary>Initializes a new instance of the <see cref="BookApi.Data.AppDbContext"/> class.</summary>
    /// <param name="options">An object that represents options for the <see cref="Microsoft.EntityFrameworkCore.DbContext"/>.</param>
    public AppDbContext(DbContextOptions options) : base(options) { }

    /// <summary>Configures the model.</summary>
    /// <param name="modelBuilder">An object provides a simple API surface for configuring a <see cref="Microsoft.EntityFrameworkCore.Metadata.IMutableModel" />.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new AuthorEntityTypeConfiguration());
      modelBuilder.ApplyConfiguration(new BookEntityTypeConfiguration());
    }
  }
}
