using AspImpactaBiblioteca.Models.Entities;
using AspImpactaBiblioteca.Models.Interfaces;
using Ninject;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace AspImpactaBiblioteca.Controllers
{
    public class AutorController : Controller
    {        
        private readonly IAutorRepository autorRepository;

        [Inject]
        public AutorController(IAutorRepository _autorRepository)
        {            
            autorRepository = _autorRepository;
        }
        
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult Listar()
        {            
            return View(autorRepository.ListarTodos());
        }
        
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Autor autor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    autorRepository.Adicionar(autor);
                    autorRepository.Salvar();

                    return RedirectToAction("Listar");
                }

                return View(autor);

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
            
            return View(autorRepository.BuscarPorId(id));
        }
        
        [HttpPost]
        public ActionResult Edit(Autor autor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    autorRepository.Atualizar(autor);
                    autorRepository.Salvar();

                    return RedirectToAction("Listar");
                }

                return View(autor);

            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ContentResult Delete(int id)
        {
            autorRepository.ExcluirPorId(id);
            autorRepository.Salvar();

            return Content("Excluído com sucesso");
        }

    }
}
