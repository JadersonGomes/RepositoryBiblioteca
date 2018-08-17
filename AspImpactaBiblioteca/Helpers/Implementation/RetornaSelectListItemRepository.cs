using AspImpactaBiblioteca.Helpers.Interfaces;
using AspImpactaBiblioteca.Models.Entities;
using AspImpactaBiblioteca.Models.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AspImpactaBiblioteca.Helpers
{
    public class RetornaSelectListItemRepository: IRetornaSelectListItemRepository
    {        
        private readonly IAutorRepository _AutorRepository;
        private readonly ICategoriaRepository _CategoriaRepository;
        private readonly IClienteRepository _ClienteRepository;
        private readonly ILivroRepository _LivroRepository;
        private readonly IFormaPagamentoRepository _FormaPagamentoRepository;        

        public RetornaSelectListItemRepository(IAutorRepository autorRepository, ICategoriaRepository categoriaRepository, IClienteRepository clienteRepository, ILivroRepository livroRepository, IFormaPagamentoRepository formaPagamentoRepository)
        {
            _AutorRepository = autorRepository;
            _CategoriaRepository = categoriaRepository;
            _ClienteRepository = clienteRepository;
            _LivroRepository = livroRepository;
            _FormaPagamentoRepository = formaPagamentoRepository;
        }


        public List<SelectListItem> Autores()
        {
            List<Autor> listaAutor = new List<Autor>();
            listaAutor = _AutorRepository.ListarTodos();

            List<SelectListItem> listaItensAutores = listaAutor.ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.Nome,
                    Value = a.Id.ToString(),
                    Selected = false
                };

            });

            return listaItensAutores;

        }



        public List<SelectListItem> Categorias()
        {
            List<Categoria> listaCategoria = new List<Categoria>();
            listaCategoria = _CategoriaRepository.ListarTodos();

            List<SelectListItem> listaItensCategorias = listaCategoria.ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.Nome,
                    Value = a.Id.ToString(),
                    Selected = false
                };

            });

            return listaItensCategorias;

        }

        public List<SelectListItem> Clientes()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            listaClientes = _ClienteRepository.ListarTodos();

            List<SelectListItem> listaItensClientes = listaClientes.ConvertAll(c =>
            {
                return new SelectListItem()
                {
                    Text = c.Nome,
                    Value = c.Id.ToString(),
                    Selected = false
                };

            });

            return listaItensClientes;

        }

        public List<SelectListItem> LivrosDisponiveis(int id = 0)
        {

            List<Livro> listaLivrosDisponiveis = _LivroRepository.LivrosDisponiveisParaEmprestimo();

            List<SelectListItem> listaItensLivros = listaLivrosDisponiveis.ConvertAll(l =>
            {

                return new SelectListItem()
                {
                    Text = l.Nome,
                    Value = l.Id.ToString(),
                    Selected = (l.Id == id)
                };

            });

            return listaItensLivros;

        }


        public List<SelectListItem> FormaPagamento()
        {
            List<FormaPagamento> listaFormaPagamento = new List<FormaPagamento>();
            listaFormaPagamento = _FormaPagamentoRepository.ListarTodos();

            List<SelectListItem> listaItensFormaPagamento = listaFormaPagamento.ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.Nome,
                    Value = a.Id.ToString(),
                    Selected = false
                };

            });

            return listaItensFormaPagamento;

        }



    }
}