using MudBlazor;
using MudBlazor.Services;

namespace CoreMine.Client.Extensions
{
    public static class MudBlazorConfig
    {
        public static IServiceCollection ConfigureMudBlazor(this IServiceCollection services)
        {
            services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopRight;
                config.SnackbarConfiguration.PreventDuplicates = false;
                config.SnackbarConfiguration.NewestOnTop = true;
                config.SnackbarConfiguration.ShowCloseIcon = true;
                config.SnackbarConfiguration.VisibleStateDuration = 4000;
                config.SnackbarConfiguration.HideTransitionDuration = 300;
                config.SnackbarConfiguration.ShowTransitionDuration = 300;
                config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;

                config.SnackbarConfiguration.MaximumOpacity = 95;

            });

            return services;
        }
    }
}
