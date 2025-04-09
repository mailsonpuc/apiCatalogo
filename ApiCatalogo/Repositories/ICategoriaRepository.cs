using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCatalogo.Models;

namespace ApiCatalogo.Repositories
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> GetCategorias();

        Categoria GetCategoria(int id);

        Categoria Create(Categoria categoria);

        Categoria Update(Categoria categoria);

        Categoria Delete(int id);

    }
}