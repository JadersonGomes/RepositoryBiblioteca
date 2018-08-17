using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspImpactaBiblioteca.Models.Entities
{
    public class Pagamento
    {
        [Key]              
        public int Id { get; set; }
        
        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; }

        public int ClienteId { get; set; }

        [DisplayName("Valor pago")]
        public double ValorPago { get; set; }

        [DisplayName("Forma de pagamento")]
        [ForeignKey("FormaPagamentoId")]
        public virtual FormaPagamento FormaPagamento { get; set; }

        public int FormaPagamentoId { get; set; }

        [DisplayName("Data de pagamento")]
        public DateTime DataPagamento { get; set; }

       




    }

}