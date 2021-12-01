using API.Interfaces;
using API.Domain.Product.Command;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using System;
using API.Extensions;
using System.ComponentModel.DataAnnotations;

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
                //TODO: Pegar o id da empresa na requisição
                //para fazer o cadastro do produto
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
