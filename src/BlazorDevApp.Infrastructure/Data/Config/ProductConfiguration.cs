using BlazorDevApp.Core.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorDevApp.Infrastructure.Data.Config;
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Name)
               .IsRequired()
               .HasMaxLength(256);

        builder.Property(p => p.Description)
               .IsRequired()
               .HasMaxLength(1024);

        builder.Property(p => p.Price)
               .IsRequired()
               .HasColumnType("money");

        builder.HasIndex(p => p.Name)
               .IsUnique();
    }
}
