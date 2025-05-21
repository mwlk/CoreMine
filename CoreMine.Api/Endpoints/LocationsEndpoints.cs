using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.UseCases.Locations.Queries;
using CoreMine.Models.Common;
using CoreMine.Models.ViewModels;

namespace CoreMine.Api.Endpoints
{
    public static partial class EndpointRegister
    {
        public static void MapLocationsEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/locations")
                .WithTags("Locations");

            // GET: api/locations
            group.MapGet("/", async (
               [AsParameters] GetLocationsQuery query,
               IQueryHandler<GetLocationsQuery, PagedResult<LocationViewModel>> handler,
               CancellationToken cancellationToken) =>
            {
                var result = await handler.HandleAsync(query, cancellationToken);
                return Results.Ok(result);
            })
                .WithDescription("Listado de Ubicaciones de respuestos")
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound);
        }
    }
}
