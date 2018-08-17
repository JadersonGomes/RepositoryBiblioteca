using AspImpactaBiblioteca.Context;
using AspImpactaBiblioteca.Helpers.Interfaces;
using AspImpactaBiblioteca.Models.Entities;
using AspImpactaBiblioteca.Models.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AspImpactaBiblioteca.Controllers
{
    public class PagamentoController : Controller
    {        

        private readonly IPagamentoRepository repositoryPagamento;
        private readonly IFormaPagamentoRepository repositoryFormaPagamento;
        private readonly IClienteRepository repositoryCliente;
        private readonly IEmprestimoRepository repositoryEmprestimo;
        private readonly IRetornaSelectListItemRepository retornaSelectListItemRepository;

        [Inject]
        public PagamentoController(IPagamentoRepository _repositoryPagamento, IFormaPagamentoRepository _repositoryFormaPagamento, IClienteRepository _repositoryCliente, IRetornaSelectListItemRepository _retornaSelectListItemRepository, IEmprestimoRepository _repositoryEmprestimo)
        {
            repositoryPagamento = _repositoryPagamento;
            repositoryFormaPagamento = _repositoryFormaPagamento;
            repositoryCliente = _repositoryCliente;
            repositoryEmprestimo = _repositoryEmprestimo;
            retornaSelectListItemRepository = _retornaSelectListItemRepository;
        }
        
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Create(int? id)
        {   
            //Emprestimo emprestimo = repositoryEmprestimo.BuscarPorId(id);                
            ViewBag.FormasPagamentos = retornaSelectListItemRepository.FormaPagamento();

            return View();
        }
        
        [HttpPost]
        public ActionResult Create(Pagamento pagamento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //pagamento.Cliente = _RepositoryCliente.BuscarPorId(pagamento.Cliente.Id);

                    Cliente cliente = repositoryCliente.BuscarPorCpf(pagamento.Cliente.Cpf);
                    if (cliente != null && cliente.valorPagar > 0)
                    {
                        pagamento.FormaPagamento = repositoryFormaPagamento.BuscarPorId(pagamento.FormaPagamentoId);
                        pagamento.Cliente = cliente;

                        repositoryPagamento.Adicionar(pagamento);
                        repositoryPagamento.Salvar();

                        repositoryPagamento.RegistrarPagamento(pagamento);                        

                        return RedirectToAction("Listar", "Pagamento");

                    }  else if(cliente.valorPagar == 0)
                    {
                        pagamento.FormaPagamento = repositoryFormaPagamento.BuscarPorId(pagamento.FormaPagamentoId);
                        pagamento.Cliente = cliente;
                        repositoryPagamento.Adicionar(pagamento);
                        repositoryPagamento.Salvar();
                        
                    }                   
                }

                return View(pagamento);

                
            }
            catch(Exception e)
            {
                return View(e.Message);
            }
        }


        public ActionResult Listar()
        {            
            return View(repositoryPagamento.ListarTodos());
        }
        
        public ActionResult Edit(int id)
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
       
    }
}
