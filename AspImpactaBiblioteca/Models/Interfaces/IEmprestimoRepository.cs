using AspImpactaBiblioteca.Context;
using AspImpactaBiblioteca.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspImpactaBiblioteca.Models.Interfaces
{
    public interface IEmprestimoRepository: IRepository<Emprestimo>
    {
       
        void CalculaMultaDiaria(Emprestimo emprestimo);
        void CadastrarDevolucaoEmprestimo(Emprestimo emprestimo);
        void CadastrarEmprestimos(Emprestimo emprestimo);
        List<Emprestimo> ListarNaoDevolvidos();


    }
}