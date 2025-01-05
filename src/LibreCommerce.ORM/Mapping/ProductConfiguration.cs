using LibreCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibreCommerce.ORM.Mapping
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            
            builder.HasKey(x => x.ProductId);
            builder.Property(x => x.ProductId)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Price)
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.Description)
                .HasMaxLength(500);

            builder.Property(x => x.Category)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Image)
                .IsRequired()
                .HasMaxLength(2048);

            builder.Property(x => x.Rate)
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.Count)
                .HasColumnType("int");
        }
    }
}
