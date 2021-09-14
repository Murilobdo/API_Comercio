using System.Collections.Generic;
using API.Models;
using API.Domain.Product.Command;
using MongoDB.Driver;

namespace API.Interfaces
{
    public interface IProductRepository
    {
        void AddProduct(ProductEntity command);
        List<ProductEntity> ListProducts();
    }
}