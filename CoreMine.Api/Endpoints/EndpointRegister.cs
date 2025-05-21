namespace CoreMine.Api.Endpoints
{
    public static partial class EndpointRegister
    {
        public static void RegisterEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapLocationsEndpoints();
            app.MapMachinesEndpoints();
            app.MapProductCategoriesEndpoints();
            app.MapProductsEndpoints();
            app.MapProductStateTypesEndpoints();
            app.MapStockMovementTypesEndpoints();
            app.MapSuppliersEndpoints();
            app.MapUnitOfMeasuresEndpoints();
        }
    }
}
