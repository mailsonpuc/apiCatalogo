

namespace ApiCatalogo.Repositories
{
    public interface IUnitOfWork
    {
        IProdutoRepository ProdutoRepository { get; }
        ICategoriaRepository CategoriaRepository { get; }
        void Commit();

        //usando generico
        // IProdutoRepository<Produto> produtoRepository { get; }
        // ICategoriaRepository<Categoria> CategoriaRepository { get; }



    }
}