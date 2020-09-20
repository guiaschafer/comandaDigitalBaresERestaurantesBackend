using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComandaDigitalBaresERestaurantes.WebApi.Configuration
{
    public class CorsSettings
    {
        public string[] AllowedOriginsList => AllowedOrigins?.Split(';');
        public string AllowedOrigins { get; set; }
    }
}
