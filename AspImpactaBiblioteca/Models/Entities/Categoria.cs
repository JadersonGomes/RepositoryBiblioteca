using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspImpactaBiblioteca.Models.Entities
{
    public class Categoria
    {
        [Key]        
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Livro> Livros { get; set; }

    }
}