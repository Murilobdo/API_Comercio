using System.Collections.Generic;
using API.Interfaces;
using API.Models;
using API.Domain.Product.Command;
using MongoDB.Driver;
using System;

namespace API.Data.Repository
{
    public class ProductRepository : MongoDbContext, IProductRepository
    {

        public List<ProductEntity> ListProducts()
        {
            List<ProductEntity> listProduct = new List<ProductEntity>()
            {
                // new ProductEntity("produto 1", 20, 40, 10),
                // new ProductEntity("produto 2", 10, 30, 15)
            };
            return listProduct;
        }
        
        public void AddProduct(ProductEntity product) => Products.InsertOne(product);
        public void UpdateProduct(ProductEntity product) => Products.ReplaceOne(p => p.Id == product.Id, product);
        public void DeleteProduct(Guid id) => Products.DeleteOne(p => p.Id == id.ToString());
        public bool IfExist(string productName) => Products.Find(p => p.Name == productName).Any();
    }
}