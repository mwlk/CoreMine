using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.UseCases.Suppliers.Commands;
using CoreMine.ApplicationBusiness.UseCases.Suppliers.Queries;
using CoreMine.Models.Common;
using CoreMine.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CoreMine.Api.Endpoints
{
    public static partial class EndpointRegister
    {
        public static void MapSuppliersEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/suppliers")
                .WithTags("Suppliers");

            // GET: api/suppliers
            group.MapGet("/", async (
                [AsParameters] GetSuppliersQuery query,
                IQueryHandler<GetSuppliersQuery, PagedResult<SupplierViewModel>> handler,
                CancellationToken cancellationToken
                ) =>
            {
                var result = await handler.HandleAsync(query, cancellationToken);
                return Results.Ok(result);
            })
                .WithDescription("Listado de proveedores")
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound);

            // POST: api/suppliers
            group.MapPost("/", async (
                [FromBody] CreateSupplierCommand command,
                ICommandHandler<CreateSupplierCommand, int> handler,
                CancellationToken cancellationToken
                ) =>
            {
                var result = await handler.HandleAsync(command, cancellationToken);
                return Results.Created("", result);
            })
                .WithDescription("Creación de nuevo registro en proveedores")
                .Produces(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest);
        }
    }
}
