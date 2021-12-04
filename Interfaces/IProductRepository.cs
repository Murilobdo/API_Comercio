using System.Collections.Generic;
using API.Models;
using System;

namespace API.Interfaces
{
    public interface IProductRepository
    {
        void AddProduct(ProductEntity entity);
        IEnumerable<ProductEntity> ListProducts(Guid IdCompany);
        bool IfExist(string productName, Guid IdCompany);
        void DeleteProduct(ProductEntity entity);
        void UpdateProduct(ProductEntity productEntity);
        ProductEntity Find(Guid id);
    }
}