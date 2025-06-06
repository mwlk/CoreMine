﻿using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.UseCases.Categories.Commands;
using CoreMine.ApplicationBusiness.UseCases.Categories.Queries;
using CoreMine.Models.Common;
using CoreMine.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CoreMine.Api.Endpoints
{
    public static partial class EndpointRegister
    {
        public static void MapProductCategoriesEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/productCategories")
                .WithTags("ProductCategories");

            // GET: api/productCategories
            group.MapGet("/", async (
                [AsParameters] GetCategoriesQuery query,
                IQueryHandler<GetCategoriesQuery, PagedResult<CategoryViewModel>> handler,
                CancellationToken cancellationToken) =>
            {
                var result = await handler.HandleAsync(query, cancellationToken);
                return Results.Ok(result);
            })
                .Produces<PagedResult<CategoryViewModel>>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .WithDescription("Listar categorias de repuestos");


            // POST: api/categories
            group.MapPost("/", async (
                [FromBody] CreateCategoryCommand command,
                ICommandHandler<CreateCategoryCommand, int> handler,
                CancellationToken cancellationToken) =>
            {
                var result = await handler.HandleAsync(command, cancellationToken);
                return Results.Created("", result);
            })
                .Produces<int>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest)
                .WithDescription("Registrar nueva categoria para repuestos");


        }
    }
}
