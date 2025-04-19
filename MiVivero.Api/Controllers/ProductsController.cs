using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiVivero.ApplicationBusiness.UseCases.Products.Queries;
using MiVivero.Models.Common;
using MiVivero.Models.ViewModels;

namespace MiVivero.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PagedResult<ProductViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] GetProductsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
