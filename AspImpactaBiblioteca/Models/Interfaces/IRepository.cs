using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspImpactaBiblioteca.Models.Interfaces
{
    public interface IRepository<T>: IDisposable where T : class
    {
        void Adicionar(T model);
        void Excluir(T model);
        void ExcluirPorId(int id);
        void Atualizar(T model);
        List<T> ListarTodos();
        T BuscarPorId(int? id);
        void Salvar();

    }

}