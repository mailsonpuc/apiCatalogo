
using ApiCatalogo.DTOs;
using ApiCatalogo.DTOs.Mappings;
using ApiCatalogo.Models;
using ApiCatalogo.Pagination;
using ApiCatalogo.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace ApiCatalogo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly ILogger<CategoriasController> _logger;

        public CategoriasController(IUnitOfWork uof,
            ILogger<CategoriasController> logger)
        {
            _uof = uof;
            _logger = logger;
        }








        [HttpGet]
        public ActionResult<IEnumerable<CategoriaDTO>> Get()
        {
            var categorias = _uof.CategoriaRepository.GetAll();

            if (categorias is null)
                return NotFound("Não existem categorias...");

            // Converte cada categoria para CategoriaDto
            // e inclui em CategoriasDto 
            // var categoriasDto = new List<CategoriaDTO>();
            // foreach (var categoria in categorias)
            // {
            //     var categoriaDto = new CategoriaDTO
            //     {
            //         CategoriaId = categoria.CategoriaId,
            //         Nome = categoria.Nome,
            //         ImagemUrl = categoria.ImagemUrl
            //     };
            //     categoriasDto.Add(categoriaDto);
            // }

            var categoriasDto = categorias.ToCategoriaDTOList();

            return Ok(categoriasDto);
        }










        [HttpGet("pagination")]
        public ActionResult<IEnumerable<CategoriaDTO>> Get([FromQuery] CategoriasParameters categoriasParameters)
        {
            var categorias = _uof.CategoriaRepository.GetCategorias(categoriasParameters);

            var metadata = new
            {
                categorias.TotalCount,
                categorias.PageSize,
                categorias.CurrentPage,
                categorias.TotalPages,
                categorias.HasNext,
                categorias.HasPrevious
            };



            Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metadata));
            var categoriasDto = categorias.ToCategoriaDTOList();

            return Ok(categoriasDto);
        }








        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<CategoriaDTO> Get(int id)
        {
            var categoria = _uof.CategoriaRepository.Get(c => c.CategoriaId == id);

            if (categoria is null)
            {
                _logger.LogWarning($"Categoria com id= {id} não encontrada...");
                return NotFound($"Categoria com id= {id} não encontrada...");
            }

            //converte Categoria para CategoriaDTO
            // var categoriaDto = new CategoriaDTO()
            // {
            //     CategoriaId = categoria.CategoriaId,
            //     Nome = categoria.Nome,
            //     ImagemUrl = categoria.ImagemUrl
            // };

            var categoriaDto = categoria.ToCategoriaDTO();

            return Ok(categoriaDto);
        }





        [HttpPost]
        public ActionResult<CategoriaDTO> Post(CategoriaDTO categoriaDto)
        {
            if (categoriaDto is null)
            {
                _logger.LogWarning($"Dados inválidos...");
                return BadRequest("Dados inválidos");
            }



            var categoria = categoriaDto.ToCategoria();

            var categoriaCriada = _uof.CategoriaRepository.Create(categoria);
            _uof.Commit();

            var novaCategoriaDto = categoriaCriada.ToCategoriaDTO();



            return new CreatedAtRouteResult("ObterCategoria",
                new { id = novaCategoriaDto.CategoriaId },
                novaCategoriaDto);
        }





        [HttpPut("{id:int}")]
        public ActionResult<CategoriaDTO> Put(int id, CategoriaDTO categoriaDto)
        {
            if (id != categoriaDto.CategoriaId)
            {
                _logger.LogWarning($"Dados inválidos...");
                return BadRequest("Dados inválidos");
            }


            var categoria = categoriaDto.ToCategoria();


            var categoriaAtualizada = _uof.CategoriaRepository.Update(categoria);
            _uof.Commit();

            var categoriaAtualizadaDto = categoriaAtualizada.ToCategoriaDTO();

            return Ok(categoriaAtualizadaDto);
        }






        [HttpDelete("{id:int}")]
        public ActionResult<CategoriaDTO> Delete(int id)
        {
            var categoria = _uof.CategoriaRepository.Get(c => c.CategoriaId == id);

            if (categoria is null)
            {
                _logger.LogWarning($"Categoria com id={id} não encontrada...");
                return NotFound($"Categoria com id={id} não encontrada...");
            }

            var categoriaExcluida = _uof.CategoriaRepository.Delete(categoria);
            _uof.Commit();

            //converte Categoria para CategoriaDTO
            var categoriaExcluidaDto = categoriaExcluida.ToCategoriaDTO();


            return Ok(categoriaExcluidaDto);
        }











    }
}