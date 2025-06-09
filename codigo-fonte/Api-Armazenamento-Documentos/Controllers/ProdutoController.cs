using Api_Orcamento.Models;
using Api_Orcamento.Service;
using Microsoft.AspNetCore.Mvc;

namespace Api_Orcamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _produtoService;

        public ProdutoController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<List<Produto>> Get() =>
            await _produtoService.GetAsync();

        [HttpGet("{Id:length(24)}")]
        public async Task<ActionResult<Produto>> Get(string id)
        {
            var produto = await _produtoService.GetAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return produto;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Produto newProduto)
        {
            newProduto.Id = null;

            await _produtoService.CreateAsync(newProduto);

            return CreatedAtAction(nameof(Get), new { id = newProduto.Id }, newProduto);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Produto updateProduto)
        {
            var produto = await _produtoService.GetAsync(id);
            if (produto is null)
                return NotFound();

            updateProduto.Id = produto.Id;
            Produto updateProduto1 = updateProduto;
            await _produtoService.UpdateAsync(id, updateProduto1);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var produto = await _produtoService.GetAsync(id);
            if (produto is null)
                return NotFound();
            await _produtoService.DeleteAsync(id);
            return NoContent();
        }
    }
}