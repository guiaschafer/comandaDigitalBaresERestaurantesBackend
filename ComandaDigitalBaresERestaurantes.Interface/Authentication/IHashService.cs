using System;
using System.Collections.Generic;
using System.Text;

namespace ComandaDigitalBaresERestaurantes.Interface.Authentication
{
    public interface IHashService
    {
        string EncryptPassword(string password);
    }
}
