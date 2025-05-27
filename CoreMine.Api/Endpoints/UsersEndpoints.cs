using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.UseCases.Auth;
using CoreMine.ApplicationBusiness.UseCases.Auth.Commands;
using Microsoft.AspNetCore.Mvc;

namespace CoreMine.Api.Endpoints
{
    public static partial class EndpointRegister
    {
        public static void MapUsersEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/users")
                .WithTags("Users");

            group.MapPost("/login", async (
                [FromBody] LoginCommand command,
                ICommandHandler<LoginCommand, LoginResponse> handler,
                CancellationToken cancellationToken) =>
            {
                var result = await handler.HandleAsync(command, cancellationToken);

                if (!result.Success)
                {
                    return Results.Unauthorized();
                }

                return Results.Ok(result);
            })
                .WithDescription("Login moq del sistema")
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status401Unauthorized);
        }
    }
}
