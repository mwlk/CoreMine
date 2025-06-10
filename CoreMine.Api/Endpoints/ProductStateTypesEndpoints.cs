using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.UseCases.ProductStateTypes.Queries;
using CoreMine.Models.Common;
using CoreMine.Models.ViewModels;

namespace CoreMine.Api.Endpoints
{
    public static partial class EndpointRegister
    {
        public static void MapProductStateTypesEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/productStateTypes")
                .WithTags("ProductStateTypes");

            // GET: api/productStateTypes
            group.MapGet("/", async (
                [AsParameters] GetProductStateTypeQuery query,
                IQueryHandler<GetProductStateTypeQuery, PagedResult<ProductStateTypeViewModel>> handler,
                CancellationToken cancellationToken) =>
            {
                var result = await handler.HandleAsync(query, cancellationToken);
                return Results.Ok(result);
            })
                .Produces<PagedResult<ProductStateTypeViewModel>>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .WithDescription("Listar tipos de estados para los repuestos");

        }
    }
}
