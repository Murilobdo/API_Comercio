using API.Interfaces;
using API.Domain.Product.Command;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace API.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddProduct")]
        public IActionResult AddProduct(AddProductCommand command)
        {
            var response = _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("ListProduct")]
        public IActionResult ListProducts()
        {
            return Ok();
        }
    }
}
