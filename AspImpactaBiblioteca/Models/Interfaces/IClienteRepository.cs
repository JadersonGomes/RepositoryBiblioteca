using AspImpactaBiblioteca.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspImpactaBiblioteca.Models.Interfaces
{
    public interface IClienteRepository: IRepository<Cliente>
    {
        Cliente BuscarPorCpf(string cpf);
    }
}