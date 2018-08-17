using AspImpactaBiblioteca.Context;
using AspImpactaBiblioteca.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AspImpactaBiblioteca.Generics
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly BibliotecaContext _contexto;

        public GenericRepository(BibliotecaContext context)
        {
            _contexto = context;
        }

        public void Adicionar(T model)
        {
            _contexto.Set<T>().Add(model);
        }

        public void Atualizar(T model)
        {
            _contexto.Entry(model).State = EntityState.Modified;
        }        

        public void Excluir(T model)
        {
            _contexto.Set<T>().Remove(model);
        }

        public void ExcluirPorId(int id)
        {
            T model = _contexto.Set<T>().Find(id);
            _contexto.Set<T>().Remove(model);
        }

        public T BuscarPorId(int? id)
        {
            T model = _contexto.Set<T>().Find(id);
            return model;
        }

        public List<T> ListarTodos()
        {
            return _contexto.Set<T>().ToList();
        }

        public void Salvar()
        {
            _contexto.SaveChanges();
        }

        public void Dispose()
        {
            if (_contexto != null)
            {
                _contexto.Dispose();
            }

            GC.SuppressFinalize(this);
        }

        
    }
}