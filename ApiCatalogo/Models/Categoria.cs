

using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCatalogo.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        //construtor inicializao a lista
        public Categoria()
        {
            Produtos = new Collection<Produto>();
        }

        

        [Key]
        public int CategoriaId { get; set; }



        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(80, MinimumLength = 5, ErrorMessage = "O Nome deve ter entre 5 e 80 caracteres")]
        public string? Nome { get; set; }



        [Required]
        [StringLength(300)]
        public string? ImagemUrl { get; set; }



        //uma categoria pode te um ou muitos produtos
        public ICollection<Produto>? Produtos { get; set; }
    }
}