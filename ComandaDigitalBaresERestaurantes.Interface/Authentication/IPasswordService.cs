using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComandaDigitalBaresERestaurantes.Interface.Authentication
{
    public interface IPasswordService
    {
        Task<bool> TryChangePassword(string username, string currentPassword, string newPassword, string confirmPassword);
        bool TryValidatePassword(string password, string hashedPassword);
        bool TryValidatePasswordFormat(string password);
    }
}
