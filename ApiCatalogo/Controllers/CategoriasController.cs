using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCatalogo.Context;
using ApiCatalogo.Filters;
using ApiCatalogo.Models;
using ApiCatalogo.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
       

        //usando a inteface do repository
        private readonly IRepository<Categoria> _repository;

    

        //injeçao de dependencia - de repository
        public CategoriasController(IRepository<Categoria> repository)
        {
            _repository = repository;
        }



        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            var categorias = _repository.GetAll();
            return Ok(categorias);
        }


        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            var categoria = _repository.Get(c=> c.CategoriaId==id);

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

            var categoriaCriada = _repository.Create(categoria);

            return new CreatedAtRouteResult("ObterCategoria",
            new { id = categoriaCriada.CategoriaId }, categoriaCriada);

        }





        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return BadRequest("Ocorreu um erro");
            }

            _repository.Update(categoria);
            return Ok(categoria);
        }











        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var categoria = _repository.Get(c=> c.CategoriaId==id);
            if (categoria is null)
            {
                return NotFound("categoria não Localizado...");
            }


            var categoriaExcluida = _repository.Delete(categoria);
            return Ok(categoriaExcluida);
        }















    }
}