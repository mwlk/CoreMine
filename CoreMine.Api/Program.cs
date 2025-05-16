using Microsoft.EntityFrameworkCore;
using CoreMine.Api.Endpoints;
using CoreMine.ApplicationBusiness;
using CoreMine.Data;
using CoreMine.Data.Seed;
using CoreMine.Infraestructure;
using CoreMine.Infrastructure;
using Scalar.AspNetCore;
using CoreMine.ApplicationBusiness.Interfaces.Shared;

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

        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
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

        builder.Services.AddControllers(); 

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference();
        }

        app.UseHttpsRedirection();

        app.RegisterEndpoints();

       

        app.UseCors("AllowBlazorClientOrigin");

        
        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            
            await context.Database.MigrateAsync();

            await LoadDatabase.InsertData(context);
        }

        app.MapControllers(); 

        await app.RunAsync();
    }
}

#region CORS

#endregion

