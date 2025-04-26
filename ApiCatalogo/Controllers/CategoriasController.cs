
using ApiCatalogo.Context;
using ApiCatalogo.Filters;
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
        private readonly ILogger<CategoriasController> _logger;



        //construtor
        public CategoriasController(AppDbContext context, ILogger<CategoriasController> logger)
        {
            //injetendo a dependencia
            _context = context;
            _logger = logger;
        }







        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
        {
            return _context.Categorias.Include(p => p.Produtos).ToList();
        }



        [HttpGet]
        //api/categoria
        //usando o filtro no controle
        [ServiceFilter(typeof(ApiLoggingFilter))]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            try
            {
                //throw new Exception("ocorreu um erro");
                var categorias = _context.Categorias.AsNoTracking().ToList();
                if (categorias is null)
                {
                    return NotFound("Categorias Não encontrado");
                }

                return categorias;

            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Ocorreu um problema ao tratar sua solicitação");
            }

        }



        // [HttpGet("{id:int}", Name = "ObterCategoria")]
        // public ActionResult<Categoria> Get(int id)
        // {
        //     try
        //     {
        //         var categoria = _context.Categorias.AsNoTracking().FirstOrDefault(c => c.CategoriaId == id);
        //         if (categoria is null)
        //         {
        //             return NotFound($"categoria com id= {id} não encontrado");
        //         }

        //         return Ok(categoria);
        //     }

        //     catch (System.Exception)
        //     {

        //         return StatusCode(StatusCodes.Status500InternalServerError,
        //         "Ocorreu um problema ao tratar sua solicitação");
        //     }

        // }

        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(p => p.CategoriaId == id);

            if (categoria == null)
            {
                _logger.LogWarning($"Categoria com id= {id} não encontrada...");
                return NotFound($"Categoria com id= {id} não encontrada...");
            }
            return Ok(categoria);
        }





        // [HttpPost]
        // public ActionResult Post(Categoria categoria)
        // {
        //     if (categoria is null)
        //     {
        //         return BadRequest("Ocorreu um erro 400");
        //     }

        //     _context.Categorias.Add(categoria);
        //     _context.SaveChanges();

        //     return new CreatedAtRouteResult("ObterCategoria",
        //     new { id = categoria.CategoriaId }, categoria);

        // }
        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            if (categoria is null)
            {
                _logger.LogWarning($"Dados inválidos...");
                return BadRequest("Dados inválidos");
            }

            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriaId }, categoria);
        }






        // [HttpPut("{id:int}")]
        // public ActionResult Put(int id, Categoria categoria)
        // {
        //     if (id != categoria.CategoriaId)
        //     {
        //         return BadRequest("Não encontrado");
        //     }

        //     _context.Entry(categoria).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //     _context.SaveChanges();

        //     //return NoContent();
        //     return Ok(categoria);

        // }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                _logger.LogWarning($"Dados inválidos...");
                return BadRequest("Dados inválidos");
            }

            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(categoria);
        }







        // [HttpDelete("{id:int}")]
        // public ActionResult Delete(int id)
        // {
        //     var categoria = _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);
        //     if (categoria is null)
        //     {
        //         return NotFound($"categoria com id= {id} não Localizada...");

        //     }

        //     _context.Categorias.Remove(categoria);
        //     _context.SaveChanges();


        //     return Ok($"categoria com id= {id} removida");
        // }
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(p => p.CategoriaId == id);

            if (categoria == null)
            {
                _logger.LogWarning($"Categoria com id={id} não encontrada...");
                return NotFound($"Categoria com id={id} não encontrada...");
            }

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
            return Ok(categoria);
        }





    }
}