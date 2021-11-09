using System;
using API.Models;
using API_MongoDB.Domain.Company.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CompanyEntity> Company { get; set; }
    }
}