using System;
using System.Collections.Generic;
using System.Linq;
using API.Interfaces;
using API.Models;

namespace API.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddProduct(ProductEntity entity)
        {
            _context.Products.Add(entity);
            _context.SaveChanges();
        }

        public void DeleteProduct(ProductEntity entity)
        {
            _context.Products.Remove(entity);
            _context.SaveChanges();
        }

        public ProductEntity Find(Guid id)
        {
            return _context.Products
                .FirstOrDefault(p => p.Id == id);
        }

        public bool IfExist(string productName, Guid IdCompany)
        {
            return _context.Products
                .Where(p => p.Name == productName && p.IdCompany == IdCompany).Count() > 0;
        }

        public IEnumerable<ProductEntity> ListProducts(Guid IdCompany)
        {
            return _context.Products.Where(p => p.IdCompany == IdCompany);
        }

        public void UpdateProduct(ProductEntity entity)
        {
            _context.Products.Update(entity);
        }
    }
}