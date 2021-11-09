using System;
using System.Collections.Generic;
using API.Interfaces;
using API.Models;

namespace API.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void AddProduct(ProductEntity command)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool IfExist(string productName)
        {
            throw new NotImplementedException();
        }

        public List<ProductEntity> ListProducts()
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(ProductEntity productEntity)
        {
            throw new NotImplementedException();
        }
    }
}