using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
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


        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(80, ErrorMessage = "O nome deve ter no máximo 80 caracteres.")]
        [MinLength(5, ErrorMessage = "O nome deve ter no mínimo 5 caracteres.")]
        public string? Nome { get; set; }

        


        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(80, ErrorMessage = "O nome deve ter no máximo 80 caracteres.")]
        [MinLength(5, ErrorMessage = "O nome deve ter no mínimo 5 caracteres.")]
        public string? ImagemUrl { get; set; }

        //propiedade de navegação

        [JsonIgnore]
        public ICollection<Produto>? Produtos { get; set; }

    }
}