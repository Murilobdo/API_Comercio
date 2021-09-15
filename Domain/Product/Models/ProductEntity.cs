using System;
namespace API.Models
{
    public class ProductEntity : EntityBase
    {
        public ProductEntity(Guid guid)
        {
            Id = Guid.NewGuid().ToString();
        }

        public ProductEntity()
        {
            
        }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}