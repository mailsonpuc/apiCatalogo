using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCatalogo.Context;
using ApiCatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;

        //injeçao de dependencia - ProdutosControlle depende de AppDbContext
        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }




        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriaProdutos()
        {
            return _context.Categorias.Include(p => p.Produtos).AsNoTracking().ToList();
        }



        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            return _context.Categorias.AsNoTracking().ToList();

        }


        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            var categoria = _context.Categorias?.FirstOrDefault(p => p.CategoriaId == id);
            if (categoria is null)
            {
                return NotFound("Não encontrado");
            }

            return categoria;

        }



        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            if (categoria is null)
            {
                return BadRequest("Ocorreu um erro, cheque os dados");
            }
            _context.Categorias?.Add(categoria);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCategoria",
            new { id = categoria.CategoriaId }, categoria);

        }





        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return BadRequest("Ocorreu um erro");
            }

            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(categoria);
        }











        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var categoria = _context.Categorias?.FirstOrDefault(p => p.CategoriaId == id);
            if (categoria is null)
            {
                return NotFound("categoria não Localizado...");
            }

            _context.Categorias?.Remove(categoria);
            _context.SaveChanges();

            return Ok(categoria);
        }















    }
}