﻿namespace CoreMine.ApplicationBusiness.UseCases.Auth.Commands
{
    public class LoginCommand
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
