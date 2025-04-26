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
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        //construtor
        public ProdutosController(AppDbContext context)
        {
            //injetendo a dependencia
            _context = context;
        }



        [HttpGet]
        //api/produto
        public async Task<ActionResult<IEnumerable<Produto>>> Get()
        {
            //nao rastriada no cache AsNoTracking(), somente leitura
            var produtos = await _context.Produtos.AsNoTracking().ToListAsync();
            if (produtos is null)
            {
                return NotFound("Produtos Não encontrado");
            }

            return produtos;
        }


        [HttpGet("{id:int:min(1)}", Name = "ObterProduto")]
        public async Task<ActionResult<Produto>> Get(int id)
        {
            var produto = await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(p => p.ProdutoId == id);
            if (produto is null)
            {
                return NotFound("Produto não encontrado");
            }

            return produto;

        }




        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if (produto is null)
            {
                return BadRequest("Ocorreu um erro 400");
            }

            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto",
            new { id = produto.ProdutoId }, produto);

        }





        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest("Não encontrado");
            }

            _context.Entry(produto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            //return NoContent();
            return Ok(produto);

        }




        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto =  _context.Produtos.FirstOrDefault(p => p.ProdutoId ==id);
            if(produto is null)
            {
                return NotFound("Produto não localizado...");

            }

            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            //return Ok(produto);
            return Ok("ok o produto foi removido");
        }





    }
}