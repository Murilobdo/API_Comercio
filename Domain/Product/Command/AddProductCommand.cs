using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace API.Domain.Product.Command
{
    public class AddProductCommand : IRequest<string>
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Digite um valor valido")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Digite um valor valido")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O valor deve ser maior que 0")]
        public int Quantity { get; set; }

        public Guid IdCompany { get; set; }
    }
}