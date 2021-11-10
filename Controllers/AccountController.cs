using API.Interfaces;
using API.Domain.Product.Command;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using System;
using API.Extensions;
using API_MongoDB.Domain.Company.Commands;

namespace API.Controllers
{
    [ApiController]
    [Route(template:"v1")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody]LoginCompanyCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(Task.FromResult("Algo aconteceu ao tentar fazer o login, " + ex.GetFullMessage()));
            }
        }

        [HttpPost("EditProduct")]
        public async Task<IActionResult> EditProduct([FromBody] UpdateProductCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(Task.FromResult("Algo aconteceu ao tentar editar um produto, " + ex.GetFullMessage()));
            }
        }

        [HttpPost("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(Task.FromResult("Algo aconteceu ao tentar deletar um produto, " + ex.GetFullMessage()));
            }
        }
    }
}
