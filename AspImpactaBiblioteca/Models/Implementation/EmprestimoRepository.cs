using AspImpactaBiblioteca.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspImpactaBiblioteca.Context;
using AspImpactaBiblioteca.Models.Interfaces;
using System.Data.Entity;
using AspImpactaBiblioteca.Models.Entities;
using Ninject;

namespace AspImpactaBiblioteca.Models.Implementation
{
    public class EmprestimoRepository : GenericRepository<Emprestimo>, IEmprestimoRepository
    {
        private readonly ILivroRepository _LivroRepository;
        private readonly IClienteRepository _ClienteRepository;

        [Inject]
        public EmprestimoRepository(BibliotecaContext context, ILivroRepository livroRepository, IClienteRepository clienteRepository) : base(context)
        {
            _LivroRepository = livroRepository;
            _ClienteRepository = clienteRepository;
        }

        public void CadastrarEmprestimos(Emprestimo emprestimo)
        {            
            emprestimo.Livro = _LivroRepository.BuscarPorId(emprestimo.LivroId);
            emprestimo.Cliente = _ClienteRepository.BuscarPorId(emprestimo.ClienteId);
            _LivroRepository.AtualizaQuantidadeLivroEmprestado(emprestimo.LivroId);


        }

        public void CadastrarDevolucaoEmprestimo(Emprestimo emprestimo)
        {            
            CalculaMultaDiaria(emprestimo);

            if (emprestimo.Cliente.valorPagar > 0)
            {
                _LivroRepository.AtualizaQuantidadeLivroDevolvido(emprestimo.Livro.Id);
                emprestimo.Devolvido = true;

                base.Atualizar(emprestimo);                
                _LivroRepository.Salvar();

            } else
            {
                _LivroRepository.AtualizaQuantidadeLivroDevolvido(emprestimo.Livro.Id);
                emprestimo.Devolvido = true;
               
                _LivroRepository.Salvar();
            }
            
            
        }

        public List<Emprestimo> ListarNaoDevolvidos()
        {
            return _contexto.Emprestimos.Where(e => e.Devolvido == false).ToList();
        }

        public void CalculaMultaDiaria(Emprestimo emprestimo)
        {
            double valorPagar = 0;            
                        
            //emprestimo.Cliente = base._contexto.Clientes.Find(emprestimo.ClienteId);

            if (emprestimo != null)
            {
                if (DateTime.Compare(emprestimo.DataDevolucao, DateTime.Now) < 0)
                {
                    TimeSpan diferencaDias = DateTime.Now - emprestimo.DataDevolucao;
                    emprestimo.Cliente.valorPagar += (diferencaDias.Days) * 2;
                }
                else
                {
                    emprestimo.Cliente.valorPagar += valorPagar;
                }

                _ClienteRepository.Atualizar(emprestimo.Cliente);
                base.Atualizar(emprestimo);
                base.Salvar();
            }

        }

    }
}