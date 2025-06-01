using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.UseCases.StockLevels.Commands;
using CoreMine.ApplicationBusiness.UseCases.Stocks.Queries;
using CoreMine.Models.Common;
using CoreMine.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CoreMine.Api.Endpoints
{
    public static partial class EndpointRegister
    {
        public static void MapStockLevelsEndpoint(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/stockLevels")
                .WithTags("StockLevels");

            // GET: api/stockLevels
            group.MapGet("/", async (
                [AsParameters] GetStockLevelsQuery query,
                IQueryHandler<GetStockLevelsQuery, PagedResult<StockLevelViewModel>> handler,
                CancellationToken cancellationToken) =>
            {
                var result = await handler.HandleAsync(query, cancellationToken);

                return Results.Ok(result);
            })
                .Produces<PagedResult<StockLevelViewModel>>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .WithDescription("Listar niveles de configuración de máximos y minimos de stock");

            // POST: api/stockLevels
            group.MapPost("/", async (
                [FromBody] CreateStockLevelCommand command,
                ICommandHandler<CreateStockLevelCommand, int> handler,
                CancellationToken cancellationToken
                ) =>
            {
                var result = await handler.HandleAsync(command, cancellationToken);
                return Results.Created("", result);
            })
                .WithDescription("Registrar nueva configuración de niveles máximos y minimos de stock")
                .Produces(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest); ;
        }
    }
}
