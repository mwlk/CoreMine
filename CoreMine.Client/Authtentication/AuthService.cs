using Blazored.LocalStorage;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace CoreMine.Client.Authtentication
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly CustomAuthStateProvider _authStateProvider;

        public AuthService(HttpClient httpClient, ILocalStorageService localStorage, CustomAuthStateProvider authStateProvider)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _authStateProvider = authStateProvider;
        }

        public async Task<bool> Login(string username, string password)
        {
            var url = $"api/users/login";

            var response = await _httpClient.PostAsJsonAsync(url, new
            {
                Username = username,
                Password = password
            });

            if (response.IsSuccessStatusCode)
            {
                var result = await response
                    .Content
                    .ReadFromJsonAsync<LoginResponse>();

                await _localStorage.SetItemAsync("token", result!.Token);

                _httpClient.DefaultRequestHeaders
                    .Authorization = new AuthenticationHeaderValue("Bearer", result.Token);

                _authStateProvider.NotifyUserAuthentication(result.Token);

                return true;
            }

            return false;
        }
        private sealed class LoginResponse
        {
            public string Token { get; set; } = string.Empty;
        }
    }
}
