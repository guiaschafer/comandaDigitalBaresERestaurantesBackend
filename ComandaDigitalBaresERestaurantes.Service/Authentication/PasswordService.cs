using ComandaDigitalBaresERestaurantes.Interface;
using ComandaDigitalBaresERestaurantes.Interface.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandaDigitalBaresERestaurantes.Service.Authentication
{
    public class PasswordService : IPasswordService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IHashService hashService;

        public PasswordService(IUnitOfWork unitOfWork,
            IHashService hashService)
        {
            this.unitOfWork = unitOfWork;
            this.hashService = hashService;
        }

        public async Task<bool> TryChangePassword(string username, string currentPassword, string newPassword, string confirmPassword)
        {
            if (newPassword != confirmPassword)
            {
                throw new ArgumentException("As senha e a confirmação de senha não são iquais.");
            }
            if (!TryValidatePasswordFormat(newPassword))
            {
                throw new ArgumentException("Nova senha é inválida.");
            }
            var user = unitOfWork
                .UserRepository
                .GetOne(u => u.Login == username);

            if (!TryValidatePassword(currentPassword, user.Password))
            {
                throw new ArgumentException("A senha atual é inválida.");
            }
            user.Password = hashService
                .EncryptPassword(newPassword);
            return unitOfWork.Commit() > 0;
        }

        public bool TryValidatePassword(string password, string hashedPassword)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(hashedPassword))
            {
                throw new ArgumentException("As senhas não podem ser nulas ou vazias!");
            }
            return hashService
                .EncryptPassword(password)
                .Equals(hashedPassword);
        }

        public bool TryValidatePasswordFormat(string password)
        {
            if ((password?.Length ?? 0) < 8)
            {
                throw new ArgumentException("A senha deve ter pelo menos 8 caracteres.", nameof(password));
            }
            var hasUpperCase = false;
            var hasLowerCase = false;
            var hasNumber = false;
            foreach (var c in password.Select(c => (byte)c))
            {
                if (!hasUpperCase && c >= 65 && c <= 90)
                {
                    hasUpperCase = true;
                }
                if (!hasLowerCase && c >= 97 && c <= 122)
                {
                    hasLowerCase = true;
                }
                if (!hasNumber && c >= 48 && c <= 57)
                {
                    hasNumber = true;
                }
                if (hasUpperCase && hasLowerCase && hasNumber)
                {
                    return true;
                }
            }
            if (!hasUpperCase)
            {
                throw new ArgumentException("A senha deve ter pelo menos uma letra maiúscula.", nameof(password));
            }
            if (!hasLowerCase)
            {
                throw new ArgumentException("A senha deve ter pelo menos uma letra minúscula.", nameof(password));
            }
            if (!hasNumber)
            {
                throw new ArgumentException("A senha deve ter números.", nameof(password));
            }
            return false;
        }
    }
}
