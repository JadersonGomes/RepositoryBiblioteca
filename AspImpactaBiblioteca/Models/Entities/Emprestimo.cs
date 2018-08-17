using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspImpactaBiblioteca.Models.Entities
{
    public class Emprestimo
    {
        [Key]        
        public int Id { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; }
        
        public int ClienteId { get; set; }

        [DisplayName("Data de empréstimo")]
        public DateTime DataEmprestimo { get; set; } 

        [DisplayName("Data de devolução")]
        public DateTime DataDevolucao { get; set; }
        
        [ForeignKey("LivroId")]        
        public virtual Livro Livro { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int LivroId { get; set; }

        [DefaultValue(false)]
        public bool Devolvido { get; set; }

        [ForeignKey("PagamentoId")]        
        public virtual Pagamento Pagamento { get; set; }
        
        public int? PagamentoId { get; set; }




    }
}