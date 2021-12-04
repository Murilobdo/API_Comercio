using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace API.Domain.Product.Command
{
    public class DeleteProductCommand : IRequest<string>
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public Guid Id { get; set; }

        public Guid IdCompany { get; set; }
    }
}