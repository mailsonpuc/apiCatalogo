

using ApiCatalogo.Context;
using ApiCatalogo.Models;
using ApiCatalogo.Pagination;

namespace ApiCatalogo.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Produto> GetProdutos(ProdutosParameters produtosParames)
        {
            // throw new NotImplementedException();
            return GetAll()
            .OrderBy(p=> p.Nome)
            .Skip((produtosParames.PageNumber - 1) * produtosParames.PageSize)
            .Take(produtosParames.PageSize).ToList();
        }

        public IEnumerable<Produto> GetProdutosPorCategoria(int id)
        {
            return GetAll().Where(c => c.CategoriaId == id);
        }


    }
}