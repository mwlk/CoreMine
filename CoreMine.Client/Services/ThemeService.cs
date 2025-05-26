using Microsoft.JSInterop;

namespace CoreMine.Client.Services
{
    public class ThemeService
    {
        private const string ThemeKey = "theme";
        private readonly IJSRuntime _jsRuntime;

        public bool IsDarkMode { get; private set; }
        public event Action? OnThemeChanged;

        public ThemeService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task InitializeAsync()
        {
            var theme = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", ThemeKey) ?? "material";
            IsDarkMode = theme.Contains("dark", StringComparison.OrdinalIgnoreCase);
            await SetTheme(theme);
        }

        public async Task ToggleTheme()
        {
            var newTheme = IsDarkMode ? "material" : "dark-base";
            await SetTheme(newTheme);
        }

        private async Task SetTheme(string theme)
        {
            IsDarkMode = theme.Contains("dark", StringComparison.OrdinalIgnoreCase);
            await _jsRuntime.InvokeVoidAsync("setRadzenTheme", theme);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", ThemeKey, theme);
            OnThemeChanged?.Invoke();
        }
    }
}

