using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.UseCases.Products.Queries;
using CoreMine.Data.ReadModels;
using CoreMine.Models.Common;

namespace CoreMine.Api.Endpoints
{
    public static partial class EndpointRegister
    {
        public static void MapProductsEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/products")
                .WithTags("Products");

            group.MapGet("/", async ([AsParameters] GetProductsQuery query,
                IQueryHandler<GetProductsQuery, PagedResult<ProductsWithFullCategoryInfoReadModel>> handler,
                CancellationToken cancellationToken) =>
            {
                var result = await handler.HandleAsync(query, cancellationToken);
                return Results.Ok(result);
            })
                .Produces<List<ProductsWithFullCategoryInfoReadModel>>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .WithDescription("Listar repuestos");
        }
    }
}
