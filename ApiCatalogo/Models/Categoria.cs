using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogo.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        //construtor inicializando
        public Categoria()
        {
            Produtos = new Collection<Produto>();
        }
        
        [Key]
        public int CategoriaId { get; set; }

        [Required]
        [StringLength(80)]
        public string? Nome { get; set; }

        [Required]
        [StringLength(300)]
        public string? ImagemUrl { get; set; }

        //propiedade de navegação
        
        public ICollection<Produto>? Produtos { get; set; }

    }
}