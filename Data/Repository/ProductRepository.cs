using System.Collections.Generic;
using API.Interfaces;
using API.Models;
using API.Domain.Product.Command;
using MongoDB.Driver;

namespace API.Data.Repository
{
    public class ProductRepository : MongoDbContext, IProductRepository
    {
        public void AddProduct(ProductEntity product)
        {
            Products.InsertOne(product);
        }

        public List<ProductEntity> ListProducts()
        {
            List<ProductEntity> listProduct = new List<ProductEntity>()
            {
                new ProductEntity("produto 1", 20, 40, 10),
                new ProductEntity("produto 2", 10, 30, 15)
            };
            return listProduct;
        }
    }
}