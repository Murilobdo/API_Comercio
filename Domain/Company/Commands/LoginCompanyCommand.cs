using System.ComponentModel.DataAnnotations;
using MediatR;
namespace API_MongoDB.Domain.Company.Commands
{
    public class LoginCompanyCommand : IRequest<string>
    {   
        [Required(ErrorMessage = "Login obrigatório")]
        public string NameCompany { get; set; }
        
        [Required(ErrorMessage = "Senha obrigatório")]
        public string Password { get; set; }
    }
}