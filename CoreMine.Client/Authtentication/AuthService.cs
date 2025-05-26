using Blazored.LocalStorage;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace CoreMine.Client.Authtentication
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public AuthService(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
        }

        public async Task<bool> Login(string username, string password)
        {
            var response = await _httpClient.PostAsJsonAsync("/login", new
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
