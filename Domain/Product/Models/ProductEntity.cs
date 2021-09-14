using System;
namespace API.Models
{
    public class ProductEntity : EntityBase
    {
        public ProductEntity()
        {
        }

        public ProductEntity(string name, decimal cost, decimal price, int quantity)
        {
            Id = Guid.NewGuid();
            Name = name;
            Cost = cost;
            Price = price;
            Quantity = quantity;
        }

        public string Name { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}