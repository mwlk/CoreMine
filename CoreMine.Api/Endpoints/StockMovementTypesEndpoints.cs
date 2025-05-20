using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.UseCases.StockMovementTypes.Queries;
using CoreMine.Models.Common;
using CoreMine.Models.ViewModels;

namespace CoreMine.Api.Endpoints
{
    public static partial class EndpointRegister
    {
        public static void MapStockMovementTypesEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/stockMovementTypes")
                .WithTags("StockMovementTypes");

            // GET: api/stockMovementTypes
            group.MapGet("/", async (
                [AsParameters] GetStockMovementTypesQuery query,
                IQueryHandler<GetStockMovementTypesQuery, PagedResult<StockMovementTypeViewModel>> handler,
                CancellationToken cancellationToken) =>
            {
                var result = await handler.HandleAsync(query, cancellationToken);
                return Results.Ok(result);
            })
                .Produces<PagedResult<StockMovementTypeViewModel>>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status400BadRequest)
                .WithDescription("Listado de tipos de movimientos de stock");
        }
    }
}
