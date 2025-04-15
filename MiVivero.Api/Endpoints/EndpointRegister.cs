namespace MiVivero.Api.Endpoints
{
    public static partial class EndpointRegister
    {
        public static void RegisterEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapProductsEndpoints();
        }
    }
}
