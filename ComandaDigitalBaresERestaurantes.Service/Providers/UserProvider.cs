using ComandaDigitalBaresERestaurantes.Aplicacao.Domain.Entity;
using ComandaDigitalBaresERestaurantes.Interface;
using ComandaDigitalBaresERestaurantes.Interface.Authentication;
using ComandaDigitalBaresERestaurantes.Interface.Dtos;
using ComandaDigitalBaresERestaurantes.Interface.Mappers;
using ComandaDigitalBaresERestaurantes.Interface.Providers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComandaDigitalBaresERestaurantes.Service.Providers
{
    public class UserProvider : IUserProvider
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserMapper mapper;
        private readonly IHashService hashService;

        public UserProvider(IUnitOfWork unitOfWork,
            IUserMapper mapper,
            IHashService hashService
            )
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.hashService = hashService;
        }

        public int AddUser(UserDto user)
        {
            unitOfWork.ClientRepository.Add(new Client
            {
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Cpf = user.Cpf,
                Cellphone = user.Cellphone,
                User = new User
                {
                    Login = user.Email,
                    Password = hashService.EncryptPassword(user.Password),
                    Perfil = Aplicacao.Domain.Enum.Perfil.Client,
                    Active = true
                }
            });

            return unitOfWork.Commit();
        }

        public UserDto GetUserAsync(string login)
        {
            var user = unitOfWork.UserRepository.GetOne(u => u.Login.ToUpper() == login.ToUpper());
            return mapper.MapToDto(user);


        }
    }
}
