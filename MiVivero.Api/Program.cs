using MediatR;
using Microsoft.EntityFrameworkCore;
using MiVivero.ApplicationBusiness;
using MiVivero.Data;
using MiVivero.Data.Seed;
using MiVivero.Infrastructure;
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

        var summaries = new[]
        {
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

        app.MapGet("/weatherforecast", () =>
        {
            var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
                .ToArray();
            return forecast;
        })
        .WithName("GetWeatherForecast");

        app.MapGet("/products", async (IMediator mediator, CancellationToken cancellationToken) =>
        {
            var query = new MiVivero.ApplicationBusiness.UseCases.Products.Queries.GetAllProductsQuery();
            var products = await mediator.Send(query, cancellationToken);
            return Results.Ok(products);
        }).WithName("GetProducts");

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

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
