

using ApiCatalogo.Models;

namespace ApiCatalogo.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        //definido um metodo especifico pra esse
        IEnumerable<Produto> GetProdutosPorCategoria(int id);

        
    }
}