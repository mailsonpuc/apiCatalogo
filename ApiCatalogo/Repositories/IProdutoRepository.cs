

using ApiCatalogo.Models;
using ApiCatalogo.Pagination;

namespace ApiCatalogo.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        //definido um metodo especifico pra esse
        // IEnumerable<Produto> GetProdutos(ProdutosParameters produtosParames);

        PagedList<Produto> GetProdutos(ProdutosParameters produtosParams);

        IEnumerable<Produto> GetProdutosPorCategoria(int id);


    }
}