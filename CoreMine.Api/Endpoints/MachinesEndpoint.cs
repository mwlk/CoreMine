using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.UseCases.Machines.Commands;
using CoreMine.ApplicationBusiness.UseCases.Machines.Queries;
using CoreMine.Models.Common;
using CoreMine.Models.ViewModels;

namespace CoreMine.Api.Endpoints
{
    public static partial class EndpointRegister
    {
        public static void MapMachinesEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/machines")
                            .WithTags("Machines")
                            ;

            // POST: api/machines
            group.MapPost("/", async (
                CreateMachineCommand command,
                ICommandHandler<CreateMachineCommand, int> handler,
                CancellationToken cancellationToken) =>
            {
                var result = await handler.HandleAsync(command, cancellationToken);
                return Results.Created("", result);
            })
                .WithDescription("Creación de nuevo registro para máquinas en la bbdd")
                .Produces(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest);

            // GET: api/machines
            group.MapGet("/", async(
                [AsParameters] GetMachinesQuery query,
                IQueryHandler<GetMachinesQuery, PagedResult<MachineViewModel>> handler,
                CancellationToken cancellationToken
                ) =>
            {
                var result = await handler.HandleAsync(query, cancellationToken);
                return Results.Ok(result);
            })
                .WithDescription("Listado de máquinas registradas")
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound);
        }
    }
}
