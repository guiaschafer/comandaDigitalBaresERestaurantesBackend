using ComandaDigitalBaresERestaurantes.Interface.Authentication;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using static System.Text.Encoding;

namespace ComandaDigitalBaresERestaurantes.Service.Authentication
{
    public class HashService : IHashService
    {
        public string EncryptPassword(string password)
        {
            using (var sha512 = SHA512.Create())
            {
                var hashPassword = sha512
                    .ComputeHash(UTF8.GetBytes(password));
                return BitConverter
                    .ToString(hashPassword)
                    .Replace("-", "");
            }
        }
    }
}
