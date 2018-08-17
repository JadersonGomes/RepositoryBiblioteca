using AspImpactaBiblioteca.Models.Entities;
using AspImpactaBiblioteca.Models.Interfaces;
using Ninject;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace AspImpactaBiblioteca.Controllers
{
    public class CategoriaController : Controller
    {
        
        private readonly ICategoriaRepository categoriaRepository;

        [Inject]
        public CategoriaController(ICategoriaRepository _categoriaRepository)
        {
            categoriaRepository = _categoriaRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                categoriaRepository.Adicionar(categoria);
                categoriaRepository.Salvar();

                return RedirectToAction("Listar");
            }

            return View(categoria);
        }

        public ActionResult Listar()
        {            
            return View(categoriaRepository.ListarTodos());
        }

        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            return View(categoriaRepository.BuscarPorId(id));
        }

        [HttpPost]
        public ActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                categoriaRepository.Atualizar(categoria);
                categoriaRepository.Salvar();

                return RedirectToAction("Listar");
            }

            return View(categoria);   
        }

        [HttpPost]
        public ContentResult Delete(int id)
        {
            categoriaRepository.ExcluirPorId(id);
            categoriaRepository.Salvar();

            return Content("Categoria excluída com sucesso.");
        }

    }

}