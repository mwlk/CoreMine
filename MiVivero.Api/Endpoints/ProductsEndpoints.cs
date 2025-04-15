using MediatR;
using MiVivero.ApplicationBusiness.UseCases.Products.Queries;
using MiVivero.Models.ViewModels;

namespace MiVivero.Api.Endpoints
{
    public static partial class EndpointRegister
    {
        public static void MapProductsEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/products")
                .WithTags("Products");

            group.MapGet("/", async (IMediator mediator, [AsParameters] GetProductsQuery query) =>
            {
                var result = await mediator.Send(query);
                return Results.Ok(result);
            })
                .Produces<List<ProductViewModel>>(StatusCodes.Status200OK);
        }
    }
}
