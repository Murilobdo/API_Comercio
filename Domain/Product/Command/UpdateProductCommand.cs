using System;

namespace API.Domain.Product.Command
{
    public class UpdateProductCommand : AddProductCommand
    {
        public UpdateProductCommand()
        {
            
        }

        public Guid Id { get; set; }
    }
}