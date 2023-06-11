// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace BookApi.Book.Data
{
  using Microsoft.EntityFrameworkCore;
  using Microsoft.EntityFrameworkCore.Metadata.Builders;
  using Microsoft.EntityFrameworkCore.ValueGeneration;

  using BookApi.Author.Data;
  using BookApi.Data.Book;

  /// <summary>Defines an entity type configuration for the <see cref="BookApi.Book.Data.BookEntity"/>.</summary>
  public sealed class BookEntityTypeConfiguration : IEntityTypeConfiguration<BookEntity>
  {
    /// <summary>Configures the entity of type <see cref="BookApi.Book.Data.BookEntity"/>.</summary>
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
             .HasMaxLength(255);

      builder.Property(entity => entity.Description)
             .HasColumnName("description")
             .IsRequired()
             .HasMaxLength(255);

      builder.Property(entity => entity.Pages)
             .HasColumnName("pages")
             .IsRequired();

      builder.Ignore(entity => entity.Authors);
      builder.HasMany(entity => entity.BookAuthors)
             .WithMany(entity => entity.Books)
             .UsingEntity<BookAuthorEntity>(
                "book_author",
                builder => builder.HasOne<AuthorEntity>()
                                  .WithMany()
                                  .HasForeignKey(entity => entity.AuthorId)
                                  .HasPrincipalKey(entity => entity.Id),
                builder => builder.HasOne<BookEntity>()
                                  .WithMany()
                                  .HasForeignKey(entity => entity.BookId)
                                  .HasPrincipalKey(entity => entity.Id),
                builder =>
                {
                  builder.Property(entity => entity.AuthorId)
                         .HasColumnName("author_id")
                         .IsRequired();

                  builder.Property(entity => entity.BookId)
                         .HasColumnName("book_id")
                         .IsRequired();
                }
              );
    }
  }
}
