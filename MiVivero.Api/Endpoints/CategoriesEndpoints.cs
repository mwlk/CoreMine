using MediatR;
using MiVivero.ApplicationBusiness.UseCases.Categories.Queries;
using MiVivero.Models.ViewModels;

namespace MiVivero.Api.Endpoints
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
        }
    }
}
