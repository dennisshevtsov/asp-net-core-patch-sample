// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Author.Data
{
  using Microsoft.EntityFrameworkCore;
  using Microsoft.EntityFrameworkCore.Metadata.Builders;
  using Microsoft.EntityFrameworkCore.ValueGeneration;

  using AspNetPatchSample.Book.Data;
  using AspNetPatchSample.Data.Book;

  /// <summary>Defines an entity type configuration for the <see cref="AspNetPatchSample.Author.Data.AuthorEntity"/>.</summary>
  public sealed class AuthorEntityTypeConfiguration : IEntityTypeConfiguration<AuthorEntity>
  {
    /// <summary>Configures the entity of type <see cref="AspNetPatchSample.Author.Data.AuthorEntity"/>.</summary>
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

      builder.HasMany(entity => entity.Books)
             .WithMany(entity => entity.BookAuthors)
             .UsingEntity<BookAuthorEntity>(
                "book_author",
                builder => builder.HasOne<BookEntity>()
                                  .WithMany()
                                  .HasForeignKey(entity => entity.BookId)
                                  .HasPrincipalKey(entity => entity.Id),
                builder => builder.HasOne<AuthorEntity>()
                                  .WithMany()
                                  .HasForeignKey(entity => entity.AuthorId)
                                  .HasPrincipalKey(entity => entity.Id)
              );
    }
  }
}
