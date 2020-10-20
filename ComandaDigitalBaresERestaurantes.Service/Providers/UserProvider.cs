using ComandaDigitalBaresERestaurantes.Interface;
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

        public UserProvider(IUnitOfWork unitOfWork,
            IUserMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public UserDto GetUserAsync(string login)
        {
            var user = unitOfWork.UserRepository.GetOne(u => u.Login == login);
            return mapper.MapToDto(user);


        }
    }
}
