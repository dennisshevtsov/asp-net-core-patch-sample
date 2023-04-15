// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Infrastructure.Entity
{
  using Microsoft.EntityFrameworkCore;
  using Microsoft.EntityFrameworkCore.Metadata.Builders;
  using Microsoft.EntityFrameworkCore.ValueGeneration;

  /// <summary>Defines an entity type configuration for the <see cref="AspNetPatchSample.Infrastructure.Entity.OrderEntity"/>.</summary>
  public sealed class OrderEntityTypeConfiguration : IEntityTypeConfiguration<OrderEntity>
  {
    /// <summary>Configures the entity of type <see cref="AspNetPatchSample.Infrastructure.Entity.OrderEntity"/>.</summary>
    /// <param name="builder">An object that provides a simple API for configuring an <see cref="Microsoft.EntityFrameworkCore.Metadata.IMutableEntityType" />.</param>
    public void Configure(EntityTypeBuilder<OrderEntity> builder)
    {
      builder.ToTable("orders");
      builder.HasKey(entity => entity.OrderId);

      builder.Property(entity => entity.OrderId)
             .HasColumnName("id")
             .IsRequired()
             .ValueGeneratedOnAdd()
             .HasValueGenerator<GuidValueGenerator>();

      builder.Property(entity => entity.Name)
             .HasColumnName("name")
             .IsRequired()
             .HasMaxLength(256);

      builder.Property(entity => entity.Description)
             .HasColumnName("description")
             .HasMaxLength(256);
    }
  }
}
