
using ApiCatalogo.Context;
using ApiCatalogo.Models;
using ApiCatalogo.Pagination;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Repositories
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {


        public CategoriaRepository(AppDbContext context) : base(context)
        {
        }







        public PagedList<Categoria> GetCategorias(CategoriasParameters categoriasParameters)
        {
            var categorias = GetAll().OrderBy(p => p.CategoriaId).AsQueryable();

            var categoriasOrdenados = PagedList<Categoria>.ToPagedList(categorias,
                        categoriasParameters.PageNumber, categoriasParameters.PageSize);

            return categoriasOrdenados;
        }





        public PagedList<Categoria> GetCategoriasFiltroNome(CategoriasFiltroNome categoriasParams)
        {
            var categorias = GetAll().AsQueryable();

            if (!string.IsNullOrEmpty(categoriasParams.Nome))
            {
                categorias = categorias.Where(c => c.Nome.Contains(categoriasParams.Nome));
            }

            var categoriasFiltradas = PagedList<Categoria>.ToPagedList(categorias,
                                       categoriasParams.PageNumber, categoriasParams.PageSize);

            return categoriasFiltradas;
        }





    }
}