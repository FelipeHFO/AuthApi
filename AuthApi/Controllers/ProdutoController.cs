using System.Net;
using Domain.Entities;
using Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.Constants;

namespace AuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        // Injeção de dependência da camada de serviço
        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        // GET api/produto
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var produtos = await _produtoService.ObterTodosAsync();
                return Ok(produtos); // Retorna 200 com os produtos
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    new { message = MensagensErro.MensagemPadrao, error = ex.Message });
            }
        }

        // GET api/produto/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var produto = await _produtoService.ObterPorIdAsync(id);
                return Ok(produto); // Retorna 200 com o produto
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    new { message = MensagensErro.MensagemPadrao, error = ex.Message });
            }
        }

        // POST api/produto
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Produto produto)
        {
            if (produto == null)
            {
                return BadRequest(new { message = MensagensErro.ProdutoInvalido }); // Retorna 400 se o produto não for enviado corretamente
            }

            try
            {
                await _produtoService.AdicionarAsync(produto); // Cria o produto
                return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto); // Retorna 201
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    new { message = MensagensErro.MensagemPadrao, error = ex.Message });
            }
        }

        // PUT api/produto/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Produto produto)
        {
            if (produto == null || produto.Id != id)
            {
                return BadRequest(new { message = MensagensErro.DadosInvalidos }); // Verifica se os dados são válidos
            }

            try
            {
                var updatedProduto = await _produtoService.AtualizarAsync(produto);
                return NoContent(); // Retorna 204 se a atualização for bem-sucedida
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    new { message = MensagensErro.MensagemPadrao, error = ex.Message });
            }
        }

        // DELETE api/produto/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _produtoService.RemoverAsync(id); // Exclui o produto
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
