using AspImpactaBiblioteca.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspImpactaBiblioteca.Models.Interfaces
{
    public interface ILivroRepository: IRepository<Livro>
    {
        void AtualizaQuantidadeLivroEmprestado(int id);
        void AtualizaQuantidadeLivroDevolvido(int id);
        List<Livro> LivrosDisponiveisParaEmprestimo();


    }
}