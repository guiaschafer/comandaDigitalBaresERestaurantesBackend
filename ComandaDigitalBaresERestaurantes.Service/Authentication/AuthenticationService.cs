using ComandaDigitalBaresERestaurantes.Interface;
using ComandaDigitalBaresERestaurantes.Interface.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ComandaDigitalBaresERestaurantes.Service.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPasswordService passwordService;


        public AuthenticationService(IUnitOfWork unitOfWork,
            IPasswordService passwordService)
        {
            this.unitOfWork = unitOfWork;
            this.passwordService = passwordService;

        }

        public async Task<bool> AuthenticateAsync(string username, string password)
        {
            var user = unitOfWork
                .UserRepository
                .GetOne(u => u.Login == username);
            return passwordService
                .TryValidatePassword(password, user?.Password);
        }

    }
}
