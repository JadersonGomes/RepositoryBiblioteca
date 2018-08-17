using AspImpactaBiblioteca.Helpers.Interfaces;
using AspImpactaBiblioteca.Models.Entities;
using AspImpactaBiblioteca.Models.Interfaces;
using Ninject;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AspImpactaBiblioteca.Controllers
{
    public class EmprestimoController : Controller
    {
        private readonly IRetornaSelectListItemRepository retornaSelectListItemRepository;
        private readonly IEmprestimoRepository emprestimoRepository;

        [Inject]
        public EmprestimoController(IRetornaSelectListItemRepository _retornaSelectListItemRepository, IEmprestimoRepository _emprestimoRepository)
        {
            retornaSelectListItemRepository = _retornaSelectListItemRepository;
            emprestimoRepository = _emprestimoRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listar()
        {                      
            return View(emprestimoRepository.ListarNaoDevolvidos());
        }

        public ActionResult Create()
        {
            ViewBag.LivrosDisponiveis = retornaSelectListItemRepository.LivrosDisponiveis();
            ViewBag.Clientes = retornaSelectListItemRepository.Clientes();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Emprestimo emprestimo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    emprestimoRepository.CadastrarEmprestimos(emprestimo);
                    emprestimoRepository.Adicionar(emprestimo);
                    emprestimoRepository.Salvar();                                    

                     return RedirectToAction("Listar");
                }

                return View(emprestimo);

            }
            catch
            {
                return View(emprestimo);
            }
        }

        public ActionResult Edit(int id)
        {
            ViewBag.LivrosEditar = retornaSelectListItemRepository.LivrosDisponiveis();
            ViewBag.ClientesEditar = retornaSelectListItemRepository.Clientes();
           
            return View(emprestimoRepository.BuscarPorId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Emprestimo emprestimo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    emprestimoRepository.Atualizar(emprestimo);
                    emprestimoRepository.Salvar();

                    return RedirectToAction("Listar");
                }

                ViewBag.LivrosEditar = retornaSelectListItemRepository.LivrosDisponiveis();
                ViewBag.ClientesEditar = retornaSelectListItemRepository.Clientes();

                return View(emprestimo);

            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ContentResult Delete(int id)
        {
            try
            {
                emprestimoRepository.ExcluirPorId(id);
                emprestimoRepository.Salvar();

                return Content("Emprestimo excluído com sucesso.");
            }
            catch
            {
                return Content("Ocorreu um erro inesperado ao tentar excluir o emprestimo.");
            }
        }

        

        public ActionResult Extrato(int id)
        {
            Emprestimo emprestimo = emprestimoRepository.BuscarPorId(id);
            emprestimoRepository.CadastrarDevolucaoEmprestimo(emprestimo);

            if (emprestimo.Cliente.valorPagar > 0)
            {
                return View(emprestimo);

            } else
            {
                return RedirectToAction("Listar", "Emprestimo");
            }
            

        }
       
    }
}
