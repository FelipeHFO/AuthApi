using System.Net;
using Domain.Entities;
using Domain.Constants;
using Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        // GET api/categoria
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var categorias = await _categoriaService.ObterTodosAsync();
                return Ok(categorias); // Retorna 200 com os categorias
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    new { message = MensagensErro.MensagemPadrao, error = ex.Message });
            }
        }

        // GET api/categoria/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var categoria = await _categoriaService.ObterPorIdAsync(id);
                return Ok(categoria); // Retorna 200 com o categoria
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    new { message = MensagensErro.MensagemPadrao, error = ex.Message });
            }
        }

        // POST api/categoria
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Categoria categoria)
        {
            if (categoria == null)
            {
                return BadRequest(new { message = MensagensErro.CategoriaInvalida }); // Retorna 400 se o categoria não for enviado corretamente
            }

            try
            {
                await _categoriaService.AdicionarAsync(categoria); // Cria o categoria
                return CreatedAtAction(nameof(Get), new { id = categoria.Id }, categoria); // Retorna 201
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    new { message = MensagensErro.MensagemPadrao, error = ex.Message });
            }
        }

        // PUT api/categoria/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Categoria categoria)
        {
            if (categoria == null || categoria.Id != id)
            {
                return BadRequest(new { message = MensagensErro.DadosInvalidos }); // Verifica se os dados são válidos
            }

            try
            {
                var updatedCategoria = await _categoriaService.AtualizarAsync(categoria);
                return NoContent(); // Retorna 204 se a atualização for bem-sucedida
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    new { message = MensagensErro.MensagemPadrao, error = ex.Message });
            }
        }

        // DELETE api/categoria/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _categoriaService.RemoverAsync(id); // Exclui o categoria
                return NoContent(); // Retorna 204 após a exclusão
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    new { message = MensagensErro.MensagemPadrao, error = ex.Message });
            }
        }
    }
}
