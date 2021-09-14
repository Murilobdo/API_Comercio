using MediatR;

namespace API.Domain.Notifications
{
    public class ProductNotifications : INotification
    {
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public ActionNotification Action { get; set; }
    }
}