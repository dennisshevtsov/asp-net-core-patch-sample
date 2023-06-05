// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace BookApi.Author.Data
{
  using Microsoft.EntityFrameworkCore;
  using Microsoft.EntityFrameworkCore.Metadata.Builders;
  using Microsoft.EntityFrameworkCore.ValueGeneration;

  using BookApi.Book.Data;
  using BookApi.Data.Book;

  /// <summary>Defines an entity type configuration for the <see cref="BookApi.Author.Data.AuthorEntity"/>.</summary>
  public sealed class AuthorEntityTypeConfiguration : IEntityTypeConfiguration<AuthorEntity>
  {
    /// <summary>Configures the entity of type <see cref="BookApi.Author.Data.AuthorEntity"/>.</summary>
    /// <param name="builder">An object that provides a simple API for configuring an <see cref="Microsoft.EntityFrameworkCore.Metadata.IMutableEntityType" />.</param>
    public void Configure(EntityTypeBuilder<AuthorEntity> builder)
    {
      builder.ToTable("author");
      builder.HasKey(entity => entity.Id);

      builder.Property(entity => entity.Id)
             .HasColumnName("id")
             .IsRequired()
             .ValueGeneratedOnAdd()
             .HasValueGenerator<GuidValueGenerator>();

      builder.Property(entity => entity.Name)
             .HasColumnName("name")
             .IsRequired()
             .HasMaxLength(256);
    }
  }
}
