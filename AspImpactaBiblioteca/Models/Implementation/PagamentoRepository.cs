using AspImpactaBiblioteca.Generics;
using AspImpactaBiblioteca.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspImpactaBiblioteca.Context;
using AspImpactaBiblioteca.Models.Entities;
using Ninject;

namespace AspImpactaBiblioteca.Models.Implementation
{
    public class PagamentoRepository : GenericRepository<Pagamento>, IPagamentoRepository
    {
        private readonly IClienteRepository _ClienteRepository;

        [Inject]
        public PagamentoRepository(BibliotecaContext context, IClienteRepository clienteRepository) : base(context)
        {
            _ClienteRepository = clienteRepository;
        }

        public void RegistrarPagamento(Pagamento pagamento)
        {            
            pagamento.Cliente.valorPagar -= pagamento.ValorPago;

            _ClienteRepository.Atualizar(pagamento.Cliente);
            _ClienteRepository.Salvar();

        }
        
    }
}