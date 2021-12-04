using API.Interfaces;
using API.Domain.Product.Command;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using System;
using API.Extensions;
using System.ComponentModel.DataAnnotations;
using API_MongoDB.Services;

namespace API.Controllers
{
    [ApiController]
    [Route(template:"v1/product")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("AddProduct")]
        [Authorize(Roles = "Dono")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductCommand command)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                command.IdCompany = TokenService.GetCompanyId(token);
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(Task.FromResult("Algo aconteceu ao tentar cadastrar o produto, " + ex.GetFullMessage()));
            }
        }

        [HttpPost("EditProduct")]
        [Authorize(Roles = "Dono")]
        public async Task<IActionResult> EditProduct([FromBody] UpdateProductCommand command)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                command.IdCompany = TokenService.GetCompanyId(token);
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(Task.FromResult("Algo aconteceu ao tentar editar um produto, " + ex.GetFullMessage()));
            }
        }

        [HttpPost("DeleteProduct")]
        [Authorize(Roles = "Dono")]
        public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductCommand command)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                command.IdCompany = TokenService.GetCompanyId(token);
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
