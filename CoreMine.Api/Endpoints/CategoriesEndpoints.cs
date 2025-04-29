using MediatR;
using CoreMine.ApplicationBusiness.UseCases.Categories.Commands;
using CoreMine.ApplicationBusiness.UseCases.Categories.Queries;
using CoreMine.Models.ViewModels;

namespace CoreMine.Api.Endpoints
{
    public static partial class EndpointRegister
    {
        public static void MapCategoriesEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/categories")
                .WithTags("Categories");

            group.MapGet("/", async (IMediator mediator, [AsParameters] GetCategoriesQuery query) =>
            {
                var result = await mediator.Send(query);
                return Results.Ok(result);
            })
                .Produces<List<CategoryViewModel>>(StatusCodes.Status200OK);

            // POST: api/categories
            group.MapPost("/", async (
                CreateCategoryCommand command,
                ISender mediator,
                CancellationToken cancellationToken) =>
            {
                var result = await mediator.Send(command, cancellationToken);
                //return Results.Created($"/api/categories/{result.Id}", result);
                return Results.Ok(result);
            })
                .Produces<int>(StatusCodes.Status200OK);
        }
    }
}
