namespace API.Domain.Product.Command
{
    public class UpdateProductCommand : AddProductCommand
    {
        public UpdateProductCommand()
        {
            
        }
        public string Id { get; set; }
    }
}