using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.UseCases.Products.Commands;
using CoreMine.ApplicationBusiness.UseCases.Products.Queries;
using CoreMine.Data.ReadModels;
using CoreMine.Models.Common;
using Microsoft.AspNetCore.Mvc;

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
                .WithDescription("Listar Repuestos");

            group.MapPost("/", async (
                [FromBody] CreateProductCommand command,
                ICommandHandler<CreateProductCommand, int> handler,
                CancellationToken cancellationToken
                ) =>
            {
                var result = await handler.HandleAsync(command, cancellationToken);

                return Results.Created($"Repuesto Creado: {result}", result);
            })
                .WithDescription("Agregar Repuesto")
                .Produces<int>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest);

        }
    }
}

