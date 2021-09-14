using System;
using MediatR;

namespace API.Domain.Product.Command
{
    public class DeleteProductCommand : IRequest<string>
    {
        public Guid Id { get; set; }
    }
}