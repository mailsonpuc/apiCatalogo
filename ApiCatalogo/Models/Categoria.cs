

using System.Collections.ObjectModel;

namespace ApiCatalogo.Models
{
    public class Categoria
    {
        //construtor inicializao a lista
        public Categoria()
        {
            Produtos = new Collection<Produto>();
        }

        public int CategoriaId { get; set; }
        public string? Nome { get; set; }
        public string? ImagemUrl { get; set; }

        //uma categoria pode te um ou muitos produtos
        public ICollection<Produto>? Produtos { get; set; }
    }
}