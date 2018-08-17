using AspImpactaBiblioteca.Generics;
using AspImpactaBiblioteca.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspImpactaBiblioteca.Context;
using AspImpactaBiblioteca.Models.Entities;

namespace AspImpactaBiblioteca.Models.Implementation
{
    public class FormaPagamentoRepository : GenericRepository<FormaPagamento>, IFormaPagamentoRepository
    {
        public FormaPagamentoRepository(BibliotecaContext context) : base(context)
        {
        }
    }
}