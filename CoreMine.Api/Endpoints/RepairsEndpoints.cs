using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.UseCases.Repairs.Commands;
using CoreMine.ApplicationBusiness.UseCases.Repairs.Queries;
using CoreMine.Models.Common;
using CoreMine.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CoreMine.Api.Endpoints
{
    public static partial class EndpointRegister
    {
        public static void MapRepairsEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/repairs")
                .WithTags("Repairs");

            // GET: api/repairs
            group.MapGet("/", async (
                [AsParameters] GetRepairsQuery query,
                IQueryHandler<GetRepairsQuery, PagedResult<RepairViewModel>> handler,
                CancellationToken cancellationToken
                ) =>
            {
                var result = await handler.HandleAsync(query, cancellationToken);
                return Results.Ok(result);
            })
                .WithDescription("Listar reparaciones")
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound);

            // POST: api/repairs
            group.MapPost("/", async (
                [FromBody] CreateRepairCommand command,
                ICommandHandler<CreateRepairCommand, int> handler,
                CancellationToken cancellationToken
                ) =>
            {
                var result = await handler.HandleAsync(command, cancellationToken);
                return Results.Created("", result);
            }).WithDescription("Registrar reparación")
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);
        }
    }
}
