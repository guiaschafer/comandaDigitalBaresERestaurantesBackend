﻿using ComandaDigitalBaresERestaurantes.Aplicacao.Context;
using ComandaDigitalBaresERestaurantes.Aplicacao.Domain.Entity;
using ComandaDigitalBaresERestaurantes.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ComandaDigitalBaresERestaurantes.Interface
{
    public interface IUnitOfWork 
    {
        IRepository<User> UserRepository { get; }
        int Commit();
    }
}