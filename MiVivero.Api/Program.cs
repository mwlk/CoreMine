using MediatR;
using Microsoft.EntityFrameworkCore;
using MiVivero.ApplicationBusiness;
using MiVivero.ApplicationBusiness.UseCases.Products.Queries;
using MiVivero.Data;
using MiVivero.Data.Seed;
using MiVivero.Infrastructure;
using MiVivero.Models.ViewModels;
using Scalar.AspNetCore;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        #region CONFIGURATIONS

        // Configurar Connection String
        builder.Services.AddPersistence(builder.Configuration);

        // Configurar MediatR y AutoMapper
        builder.Services.AddApplicationBusiness();

        // Configurar Repositories
        builder.Services.AddInfraestructure();
        #endregion

        #region CORS
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowBlazorClientOrigin",
                builder => builder.WithOrigins("https://localhost:7008")
                                    .AllowAnyHeader()
                                    .AllowAnyMethod());
        });
        #endregion

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference();
        }

        app.UseHttpsRedirection();

        app.MapGet("/products", async (IMediator mediator, CancellationToken cancellationToken) =>
        {
            var query = new GetAllProductsQuery();
            var products = await mediator.Send(query, cancellationToken);
            return Results.Ok(products);
        })
            .Produces<List<ProductViewModel>>(StatusCodes.Status200OK)
            .WithName("GetProducts");

        app.UseCors("AllowBlazorClientOrigin");

        // Ejecutar el seeding antes de correr la app
        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            // Aplica migraciones automáticamente
            await context.Database.MigrateAsync();

            await LoadDatabase.InsertData(context);
        }

        await app.RunAsync();
    }
}

#region CORS

#endregion

