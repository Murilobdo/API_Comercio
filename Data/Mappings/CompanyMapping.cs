using API.Models;
using API_MongoDB.Domain.Company.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_MongoDB.Data.Mappings
{
    public class CompanyMapping : IEntityTypeConfiguration<CompanyEntity>
    {
        public void Configure(EntityTypeBuilder<CompanyEntity> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.NameCompany)
                .IsUnique();
        }
    }
}