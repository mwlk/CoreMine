namespace CoreMine.ApplicationBusiness.UseCases.Auth
{
    public class LoginResponse
    {
        public bool Success { get; set; }
        public string? Token { get; set; }
        public string? Username { get; set; }
        public string? Error { get; set; }
    }
}
