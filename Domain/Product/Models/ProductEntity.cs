using System;
namespace API.Models
{
    public class ProductEntity : EntityBase
    {

        public ProductEntity()
        {
            // Id = Guid.NewGuid();
        }

        public string Name { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Guid IdCompany { get; set; }
    }
}