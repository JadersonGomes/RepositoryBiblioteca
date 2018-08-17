using AspImpactaBiblioteca.Helpers.Interfaces;
using AspImpactaBiblioteca.Models.Entities;
using AspImpactaBiblioteca.Models.Interfaces;
using Ninject;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace AspImpactaBiblioteca.Controllers
{
    public class LivroController : Controller
    {        
        private readonly ILivroRepository livroRepository;
        private readonly IRetornaSelectListItemRepository retornaSelectListItemRepository;

        [Inject]
        public LivroController(ILivroRepository _livroRepository, IRetornaSelectListItemRepository _retornaSelectListItemRepository)
        {
            livroRepository = _livroRepository;
            retornaSelectListItemRepository = _retornaSelectListItemRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listar()
        {            
            return View(livroRepository.ListarTodos());
        }
        
        public ActionResult Details(int id)
        {            
            return View(livroRepository.BuscarPorId(id));
        }
        
        public ActionResult Create()
        {
            ViewBag.Autores = retornaSelectListItemRepository.Autores();
            ViewBag.Categorias = retornaSelectListItemRepository.Categorias();

            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Livro livro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    livroRepository.Adicionar(livro);
                    livroRepository.Salvar();        

                    return RedirectToAction("Listar");
                }

                return View(livro);

            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult Edit(int id)
        {
            if(id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }            

            ViewBag.AutoresEditar = retornaSelectListItemRepository.Autores();
            ViewBag.CategoriasEditar = retornaSelectListItemRepository.Categorias();
                        
            return View(livroRepository.BuscarPorId(id));
        }
        
        [HttpPost]
        public ActionResult Edit(Livro livro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    livroRepository.Atualizar(livro);
                    livroRepository.Salvar();

                    return RedirectToAction("Listar");
                }

                ViewBag.AutoresEditar = retornaSelectListItemRepository.Autores();
                ViewBag.CategoriasEditar = retornaSelectListItemRepository.Categorias();

                return View(livro);                
            }
            catch
            {
                return View();
            }
        }
        
        [HttpPost]
        public ContentResult Delete(int id)
        {
            livroRepository.ExcluirPorId(id);
            livroRepository.Salvar();

            return Content("Excluído com sucesso");
        }        
      
    }
}
