using System;
using API_MongoDB.Domain.Company.Models;

namespace API.Models
{
    public class ProductEntity : EntityBase
    {

        public ProductEntity()
        {
            Id = Guid.NewGuid();
        }

        public string Name { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Guid IdCompany { get; set; }
        public CompanyEntity Company { get; set; }
        
        
    }
}