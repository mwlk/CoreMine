using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.UseCases.Stocks.Queries;
using CoreMine.Models.Common;
using CoreMine.Models.ViewModels;

namespace CoreMine.Api.Endpoints
{
    public static partial class EndpointRegister
    {
        public static void MapStocksEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/stocks")
                .WithTags("Stocks");

            // GET: api/stocks
            group.MapGet("", async (
                [AsParameters] GetStocksQuery query,
                IQueryHandler<GetStocksQuery, PagedResult<StockViewModel>> handler,
                CancellationToken cancellationToken
                ) =>
            {
                var result = await handler.HandleAsync(query, cancellationToken);
                return Results.Ok(result);
            })
                .Produces<PagedResult<StockViewModel>>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .WithDescription("Listado de stocks");
        }
    }
}
