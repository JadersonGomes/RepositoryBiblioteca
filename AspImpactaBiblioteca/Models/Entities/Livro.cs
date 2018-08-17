using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspImpactaBiblioteca.Models.Entities
{
    public class Livro
    {
        [Key]        
        public int Id { get; set; }

        [StringLength(100)]
        [DisplayName("Nome do livro")]
        public string Nome { get; set; }

        [DisplayName("Quantidade de páginas")]
        public int TotalPaginas { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        public int Quantidade { get; set; }

        [ForeignKey("CategoriaId")]
        public virtual Categoria Categoria { get; set; }

        [ForeignKey("AutorId")]
        public virtual Autor Autor { get; set; }

        public int CategoriaId { get; set; }

        public int AutorId { get; set; }

        //public int MyProperty { get; set; }


    }
}