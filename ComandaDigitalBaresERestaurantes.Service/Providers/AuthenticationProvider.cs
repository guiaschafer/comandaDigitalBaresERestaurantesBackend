using ComandaDigitalBaresERestaurantes.Interface.Authentication;
using ComandaDigitalBaresERestaurantes.Interface.Dtos;
using ComandaDigitalBaresERestaurantes.Interface.Providers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComandaDigitalBaresERestaurantes.Service.Providers
{
    public class AuthenticationProvider : IAuthenticationProvider
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IUserProvider userProvider;
        private readonly IJwtTokenService jwtTokenService;
        public AuthenticationProvider(
              IAuthenticationService authenticationService,
              IUserProvider userProvider,
              IJwtTokenService jwtTokenService
             )
        {
            this.authenticationService = authenticationService;
            this.userProvider = userProvider;
            this.jwtTokenService = jwtTokenService;
        }
        public async Task<(string hashRecoverPassword, string Token, UserDto User)> AuthenticateAsync(string username, string password, int profileId = 0)
        {
            if (await authenticationService.AuthenticateAsync(username, password))
            {
                var user =  userProvider.GetUserAsync(username);
                if (user != null)
                {
                    var result =  jwtTokenService.GetToken(user.Id, (int)user.Perfil, user.Login);
                    return (string.Empty, result, user);
                }
            }

            return (null, null, null);
        }

        public Task<(string, string, UserDto)?> VerificaSenhaExpirada(string username)
        {
            throw new NotImplementedException();
        }
    }
}
