using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiCatalogo.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }

        

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(80, ErrorMessage = "O nome deve ter no máximo 80 caracteres.")]
        [MinLength(5, ErrorMessage = "O nome deve ter no mínimo 5 caracteres.")]
        public string? Nome { get; set; }

        


        [Required(ErrorMessage = "A descrrição é obrigatório.")]
        [StringLength(80, ErrorMessage = "O nome deve ter no máximo 80 caracteres.")]
        [MinLength(5, ErrorMessage = "O nome deve ter no mínimo 5 caracteres.")]
        public string? Descricao { get; set; }



        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }



 

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(80, ErrorMessage = "O nome deve ter no máximo 80 caracteres.")]
        [MinLength(5, ErrorMessage = "O nome deve ter no mínimo 5 caracteres.")]
        public string? ImagemUrl { get; set; }

        
        public float Estoque { get; set; }


        public DateTime Datacadastro { get; set; }

        

        //um produto esta relacionado a uma categoria
        public int CategoriaId { get; set; }

        //ignorando json
        [JsonIgnore]
        public Categoria? Categoria { get; set; }
    }
}