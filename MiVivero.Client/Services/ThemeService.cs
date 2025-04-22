using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace MiVivero.Client.Services
{
    public class ThemeService
    {
        private const string ThemeKey = "isDarkMode";
        private readonly IJSRuntime _runtime;

        public ThemeService(IJSRuntime runtime)
        {
            _runtime = runtime;
        }

        public bool IsDarkMode { get; private set; } = false;

        public event Action? OnThemeChanged;

        public async Task ToggleTheme()
        {
            IsDarkMode = !IsDarkMode;
            await _runtime.InvokeVoidAsync("localStorage.setItem", ThemeKey, IsDarkMode.ToString().ToLower());
            OnThemeChanged?.Invoke();
        }

        public async Task InitializeAsync()
        {
            var result = await _runtime.InvokeAsync<string>("localStorage.getItem", ThemeKey);

            if (bool.TryParse(result, out var darkMode))
            {
                IsDarkMode = darkMode;
            }
            else
            {
                IsDarkMode = false;
            }

            OnThemeChanged?.Invoke();
        }
    }
}
