using System;
using System.Collections.Generic;
using System.Text;

namespace ComandaDigitalBaresERestaurantes.Aplicacao.UniOfWork
{
    public interface IUnitOfWork 
    {
        int SaveChanges();
    }
}
