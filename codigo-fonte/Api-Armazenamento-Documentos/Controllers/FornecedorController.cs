using Api_Orcamento.Models;
using Api_Orcamento.Service;
using Microsoft.AspNetCore.Mvc;

namespace Api_Orcamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly FornecedorService _fornecedorService;

        public FornecedorController(FornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        [HttpGet]
        public async Task<List<Fornecedor>> Get() =>
            await _fornecedorService.GetAsync();

        [HttpGet("{Id:length(24)}")]
        public async Task<ActionResult<Fornecedor>> Get(string id)
        {
            var fornecedor = await _fornecedorService.GetAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            return fornecedor;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Fornecedor newFornecedor)
        {
            newFornecedor.Id = null;

            await _fornecedorService.CreateAsync(newFornecedor);

            return CreatedAtAction(nameof(Get), new { id = newFornecedor.Id }, newFornecedor);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Fornecedor updateFornecedor)
        {
            var fornecedor = await _fornecedorService.GetAsync(id);
            if (fornecedor is null)
                return NotFound();

            updateFornecedor.Id = fornecedor.Id;
            Fornecedor updateFornecedor1 = updateFornecedor;
            await _fornecedorService.UpdateAsync(id, updateFornecedor1);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var fornecedor = await _fornecedorService.GetAsync(id);
            if (fornecedor is null)
                return NotFound();
            await _fornecedorService.DeleteAsync(id);
            return NoContent();
        }
    }
}