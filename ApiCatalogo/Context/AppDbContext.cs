

using ApiCatalogo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
// using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace ApiCatalogo.Context
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        //contruto
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        //mpeamento
        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Produto> Produtos { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}