using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_MongoDB.Data.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.Name)
                .IsUnique();

            builder.Property(p => p.Cost)
                .HasColumnType("decimal (8,2)");
            
            builder.Property(p => p.Price)
                .HasColumnType("decimal (8,2)");
        }
    }
}