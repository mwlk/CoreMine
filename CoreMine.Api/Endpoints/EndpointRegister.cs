namespace CoreMine.Api.Endpoints
{
    public static partial class EndpointRegister
    {
        public static void RegisterEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapCategoriesEndpoints();
            app.MapProductStateTypesEndpoints();
            app.MapUnitOfMeasuresEndpoints();
            app.MapStockMovementTypesEndpoints();
            app.MapProductsEndpoints();
            app.MapMachinesEndpoints();
        }
    }
}
