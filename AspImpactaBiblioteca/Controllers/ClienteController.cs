using AspImpactaBiblioteca.Models.Entities;
using AspImpactaBiblioteca.Models.Interfaces;
using Ninject;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace AspImpactaBiblioteca.Controllers
{
    public class ClienteController : Controller
    {
        
        private readonly IClienteRepository clienteRepository;

        [Inject]
        public ClienteController(IClienteRepository _clienteRepository)
        {
            clienteRepository = _clienteRepository;
        }

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Listar()
        {            
            return View(clienteRepository.ListarTodos());
        }
        
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clienteRepository.Adicionar(cliente);
                    clienteRepository.Salvar();

                    return RedirectToAction("Listar");
                }

                return View(cliente);
                
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            return View(clienteRepository.BuscarPorId(id));
        }
        
        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            try
            {
                clienteRepository.Atualizar(cliente);
                clienteRepository.Salvar();

                return RedirectToAction("Listar");
            }
            catch
            {
                return View(cliente);
            }
        }        
        
        [HttpPost]
        public ContentResult Delete(int id)
        {
            try
            {
                clienteRepository.ExcluirPorId(id);
                clienteRepository.Salvar();

                return Content("Cliente excluído com sucesso.");
            }
            catch
            {
                return Content("Ocorreu um erro inesperado.");
            }
        }

    }
}
