using ComandaDigitalBaresERestaurantes.Interface;
using ComandaDigitalBaresERestaurantes.Interface.Dtos;
using ComandaDigitalBaresERestaurantes.Interface.Providers;
using ComandaDigitalBaresERestaurantes.Service.Providers;
using ComandaDigitalBaresERestaurantes.WebApi.Request;
using ComandaDigitalBaresERestaurantes.WebApi.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComandaDigitalBaresERestaurantes.WebApi.Controllers
{
    public class LoginController : ControllerBase
    {
        private readonly IUserProvider _userProvider;
        private readonly IAuthenticationProvider _authenticationProvider;

        public LoginController(IUserProvider userProvider,
            IAuthenticationProvider authenticationProvider)
        {
            _userProvider = userProvider;
            _authenticationProvider = authenticationProvider;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Login([FromBody] LoginRequest model)
        {
            // Recupera o usuário
            var user = _userProvider.GetUserAsync(model.Username);


            (string hashRecoverPassword, string token, UserDto userDto) = (string.Empty, string.Empty, null);

            if (user != null)
            {
                (hashRecoverPassword, token, user) = await _authenticationProvider.AuthenticateAsync(user.Login, model.Password);
                if (token != null && user != null)
                {
                    return Ok(new LoginResponse
                    {
                        User = user,
                        Token = token
                    });
                }
            }

            return Unauthorized("Usuário ou senha inválidos");
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<dynamic>> Register([FromBody] UserDto model)
        {
            var user = _userProvider.GetUserAsync(model.Email);

            if(user == null)
            {
                if(_userProvider.AddUser(model) > 0)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Não foi possível realizar o cadastro");
                }
            }

            return BadRequest("Não foi possível realizar o cadastro");
        }
    }
}
