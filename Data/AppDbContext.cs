using System;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }
    }
}