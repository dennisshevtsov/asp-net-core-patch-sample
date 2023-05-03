// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Book.Data
{
  using Microsoft.EntityFrameworkCore;
  using Microsoft.EntityFrameworkCore.Metadata.Builders;
  using Microsoft.EntityFrameworkCore.ValueGeneration;

  using AspNetPatchSample.Author.Data;

  /// <summary>Defines an entity type configuration for the <see cref="AspNetPatchSample.Book.Data.BookEntity"/>.</summary>
  public sealed class BookEntityTypeConfiguration : IEntityTypeConfiguration<BookEntity>
  {
    /// <summary>Configures the entity of type <see cref="AspNetPatchSample.Book.Data.BookEntity"/>.</summary>
    /// <param name="builder">An object that provides a simple API for configuring an <see cref="Microsoft.EntityFrameworkCore.Metadata.IMutableEntityType" />.</param>
    public void Configure(EntityTypeBuilder<BookEntity> builder)
    {
      builder.ToTable("book");
      builder.HasKey(entity => entity.Id);

      builder.Property(entity => entity.Id)
             .HasColumnName("id")
             .IsRequired()
             .ValueGeneratedOnAdd()
             .HasValueGenerator<GuidValueGenerator>();

      builder.Property(entity => entity.Title)
             .HasColumnName("name")
             .IsRequired()
             .HasMaxLength(256);

      builder.Ignore(entity => entity.Author);

      builder.Property(entity => entity.Description)
             .HasColumnName("description")
             .IsRequired()
             .HasMaxLength(256);

      builder.Property(entity => entity.Pages)
             .HasColumnName("pages")
             .IsRequired();

      builder.HasMany(entity => entity.Authors)
             .WithMany(entity => entity.Books)
             .UsingEntity(
                "book_author",
                builder => builder.HasOne(typeof(BookEntity))
                                  .WithMany()
                                  .HasForeignKey("bookId")
                                  .HasPrincipalKey(nameof(BookEntity.Id)),
                builder => builder.HasOne(typeof(AuthorEntity))
                                  .WithMany()
                                  .HasForeignKey("authorId")
                                  .HasPrincipalKey(nameof(AuthorEntity.Id))
              );
    }
  }
}
