using AspImpactaBiblioteca.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace AspImpactaBiblioteca.Context
{
    public class BibliotecaContext: DbContext
    {
        public BibliotecaContext()
        {
            Database.SetInitializer<BibliotecaContext>(null);
        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<FormaPagamento> FormasPagamentos { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }

        
    }
}