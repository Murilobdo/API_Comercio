using System.Collections.Generic;
using API.Models;
using System;

namespace API.Interfaces
{
    public interface IProductRepository
    {
        void AddProduct(ProductEntity entity);
        List<ProductEntity> ListProducts();
        bool IfExist(string productName);
        void DeleteProduct(ProductEntity entity);
        void UpdateProduct(ProductEntity productEntity);
        ProductEntity Find(Guid id);
    }
}