using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.Services;
using CoreMine.ApplicationBusiness.UseCases.Auth.Commands;

namespace CoreMine.ApplicationBusiness.UseCases.Auth.Handlers
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand, LoginResponse>
    {
        private readonly TokenService _tokenService;

        public LoginCommandHandler(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public Task<LoginResponse> HandleAsync(LoginCommand command, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (command.Username == "admin" && command.Password == "password")
            {
                var token = _tokenService.GenerateToken(command.Username);

                return Task.FromResult(new LoginResponse
                {
                    Success = true,
                    Token = token,
                    Username = command.Username,
                });
            }

            return Task.FromResult(new LoginResponse
            {
                Success = false,
                Error = "Credenciales ingresadas no son correctas"
            });
        }
    }
}
