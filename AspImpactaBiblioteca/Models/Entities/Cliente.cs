using AspImpactaBiblioteca.Helpers;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspImpactaBiblioteca.Models.Entities
{
    public class Cliente
    {
        [Key]        
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [DisplayName("Nome do cliente")]
        public string Nome { get; set; }

        [DisplayName("CPF")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [ValidacaoCPF]
        public string Cpf { get; set; }

        [DisplayName("E-mail")]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Total a pagar")]
        public double valorPagar { get; set; } = 0;

        public virtual List<Pagamento> Pagamentos { get; set; }

        public virtual List<Emprestimo> Emprestimos { get; set; }



    }
}