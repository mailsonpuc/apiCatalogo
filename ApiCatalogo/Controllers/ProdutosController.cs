using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCatalogo.Context;
using ApiCatalogo.Models;
using ApiCatalogo.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController : ControllerBase
    {



        private readonly IProdutoRepository _produtoRepository;
        private readonly IRepository<Produto> _repository;

        public ProdutosController(
            IRepository<Produto> repository,
            IProdutoRepository produtoRepository
            )
        {
            _produtoRepository = produtoRepository;
            _repository = repository;

        }


        [HttpGet("produtos/{id}")]
        public ActionResult<IEnumerable<Produto>> GetProdutoscategorias(int id)
        {
            var produtos = _produtoRepository.GetProdutosPorCategoria(id);
            if (produtos is null)
                return NotFound();

            return Ok(produtos);
        }



        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _repository.GetAll();
            if (produtos is null)
            {
                return NotFound("produtos não encotrado");
            }
            return Ok(produtos);
        }



        [HttpGet("{id:int}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _repository.Get(c => c.ProdutoId == id);
            if (produto is null)
            {
                return NotFound("Não encontrado");
            }

            return Ok(produto);

        }





        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if (produto is null)
            {
                return BadRequest("Ocorreu um erro, cheque os dados");
            }

            var novoProduto = _repository.Create(produto);


            return new CreatedAtRouteResult("ObterProduto",
            new { id = novoProduto.ProdutoId }, novoProduto);

        }


        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest("Ocorreu um erro");
            }

            var produtoAtualizado = _repository.Update(produto);
            return Ok(produtoAtualizado);
        }



        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto = _repository.Get(p => p.ProdutoId == id);
            if (produto is null)
            {
                return NotFound("Produto não encontrado..");
            }

            var produtoDeletado = _repository.Delete(produto);
            return Ok(produtoDeletado);


        }

    }
}