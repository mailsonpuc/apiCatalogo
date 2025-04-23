

using ApiCatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Context
{
    public class AppDbContext : DbContext
    {
        //contruto
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}

        //mpeamento
        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Produto> Produtos { get; set; }
    }
}