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
    public class AutorRepository : GenericRepository<Autor>, IAutorRepository
    {
        public AutorRepository(BibliotecaContext context) : base(context)
        {
        }
    }
}