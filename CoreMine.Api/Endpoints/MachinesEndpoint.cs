using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.UseCases.Machines.Commands;

namespace CoreMine.Api.Endpoints
{
    public static partial class EndpointRegister
    {
        public static void MapMachinesEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/machines")
                            .WithTags("Machines")
                            ;

            // POST: api/categories
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
        }
    }
}
