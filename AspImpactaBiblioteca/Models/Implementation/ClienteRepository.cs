using AspImpactaBiblioteca.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspImpactaBiblioteca.Context;
using AspImpactaBiblioteca.Models.Interfaces;
using AspImpactaBiblioteca.Models.Entities;

namespace AspImpactaBiblioteca.Models.Implementation
{
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(BibliotecaContext context) : base(context)
        {
        }

        public Cliente BuscarPorCpf(string cpf)
        {            
            return _contexto.Clientes.FirstOrDefault(c => c.Cpf == cpf);
        }


    }
}