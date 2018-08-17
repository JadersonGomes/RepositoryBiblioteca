using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspImpactaBiblioteca.Models.Entities
{
    public class FormaPagamento
    {
        [Key]        
        public int Id { get; set; }

        [DisplayName("Forma de pagamento")]
        public string Nome { get; set; }

      

    }
}