using MediatR;

namespace API.Domain.Notifications
{
    public class ErrorNotification : INotification
    {
        public string Erro { get; set; }
        public string PilhaErro { get; set; }
    }
}