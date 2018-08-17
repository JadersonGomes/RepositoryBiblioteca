using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspImpactaBiblioteca.Helpers.Interfaces
{
    public interface IRetornaSelectListItemRepository
    {
        List<SelectListItem> Autores();
        List<SelectListItem> Categorias();
        List<SelectListItem> Clientes();
        List<SelectListItem> LivrosDisponiveis(int id = 0);
        List<SelectListItem> FormaPagamento();


    }
}