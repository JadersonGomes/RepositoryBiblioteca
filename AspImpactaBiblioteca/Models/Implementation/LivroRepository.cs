using AspImpactaBiblioteca.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspImpactaBiblioteca.Context;
using AspImpactaBiblioteca.Models.Interfaces;
using System.Web.Mvc;
using AspImpactaBiblioteca.Models.Entities;

namespace AspImpactaBiblioteca.Models.Implementation
{
    public class LivroRepository : GenericRepository<Livro>, ILivroRepository
    {
        public LivroRepository(BibliotecaContext context) : base(context)
        {            
        }

        public void AtualizaQuantidadeLivroEmprestado(int id)
        {
            Livro livro = base.BuscarPorId(id);
            livro.Quantidade -= 1;

            base.Atualizar(livro);
            base.Salvar();
        }

        public void AtualizaQuantidadeLivroDevolvido(int id)
        {
            Livro livro = base.BuscarPorId(id);
            livro.Quantidade += 1;
            this.Atualizar(livro);
        }

        public List<Livro> LivrosDisponiveisParaEmprestimo()
        {
            return _contexto.Livros.Where(l => l.Quantidade > 0).ToList();
        }
    }

    
}
