using Microsoft.AspNetCore.Mvc;
using CoreMine.ApplicationBusiness.UseCases.Products.Queries;
using CoreMine.Models.Common;
using CoreMine.Models.ViewModels;

namespace CoreMine.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //private readonly IMediator _mediator;

        //public ProductsController(IMediator mediator)
        //{
        //    _mediator = mediator;
        //}

        //[HttpGet]
        //[ProducesResponseType(typeof(PagedResult<ProductViewModel>), StatusCodes.Status200OK)]
        //public async Task<IActionResult> Get([FromQuery] GetProductsQuery query)
        //{
        //    var result = await _mediator.Send(query);
        //    return Ok(result);
        //}
    }
}
