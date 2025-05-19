using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.UseCases.UnitOfMeasures.Handlers;
using CoreMine.ApplicationBusiness.UseCases.UnitOfMeasures.Queries;
using CoreMine.Models.Common;
using CoreMine.Models.ViewModels;

namespace CoreMine.Api.Endpoints
{
    public static partial class EndpointRegister
    {
        public static void MapUnitOfMeasuresEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/unitOfMeasures")
                .WithTags("UnitOfMeasures");

            // GET: api/unitOfMeasures
            group.MapGet("/", async (
                [AsParameters] GetUnitOfMeasuresQuery query,
                IQueryHandler<GetUnitOfMeasuresQuery, PagedResult<UnitOfMeasureViewModel>> handler,
                CancellationToken cancellationToken) =>
            {
                var result = await handler.HandleAsync(query, cancellationToken);
                return Results.Ok(result);
            })
                .Produces<PagedResult<UnitOfMeasureViewModel>>(StatusCodes.Status200OK);
        }
    }

}
