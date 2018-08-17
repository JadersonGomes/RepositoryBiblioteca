using AspImpactaBiblioteca.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspImpactaBiblioteca.Models.Interfaces
{
    public interface IPagamentoRepository: IRepository<Pagamento>
    {
        void RegistrarPagamento(Pagamento pagamento);
    }
}
