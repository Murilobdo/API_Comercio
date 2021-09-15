using System.Collections.Generic;
using API.Models;
using API.Domain.Product.Command;
using MongoDB.Driver;
using System;

namespace API.Interfaces
{
    public interface IProductRepository
    {
        void AddProduct(ProductEntity command);
        List<ProductEntity> ListProducts();
        bool IfExist(string productName);
        void DeleteProduct(Guid id);
        void UpdateProduct(ProductEntity productEntity);
    }
}