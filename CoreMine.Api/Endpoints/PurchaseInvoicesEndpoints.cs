using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.UseCases.PurchaseInvoices.Commands;
using Microsoft.AspNetCore.Mvc;

namespace CoreMine.Api.Endpoints
{
    public static partial class EndpointRegister
    {
        public static void MapPurchaseInvoicesEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/purchaseInvoices")
                .WithTags("PurchaseInvoices");

            group.MapPost("/", async (
                [FromBody] CreatePurchaseInvoiceCommand command,
                ICommandHandler<CreatePurchaseInvoiceCommand, int> handler,
                CancellationToken cancellationToken
                ) =>
            {
                var result = await handler.HandleAsync(command, cancellationToken);
                return Results.Created("", result);
            })
                .Produces<int>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest)
                .WithDescription("Registrar factura de compra");
        }
    }
}
