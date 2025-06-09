using Api_Orcamento.Models;
using Api_Orcamento.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Orcamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrcamentoController : ControllerBase
    {
        private readonly OrcamentoService _orcamentoService;

        public OrcamentoController(OrcamentoService orcamentoService)
        {
            _orcamentoService = orcamentoService;
        }

        [HttpGet]
        public async Task<List<Orcamento>> Get() =>
            await _orcamentoService.GetAsync();

        [HttpGet("{Id:length(24)}")]
        public async Task<ActionResult<Orcamento>> Get(string id)
        {
            var orcamento = await _orcamentoService.GetAsync(id);
            if (orcamento == null)
            {
                return NotFound();
            }
            return orcamento;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Orcamento newOrcamento)
        {
            newOrcamento.Id = null;

            await _orcamentoService.CreateAsync(newOrcamento);

            return CreatedAtAction(nameof(Get), new { id = newOrcamento.Id }, newOrcamento);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Orcamento updateOrcamento)
        {
            var orcamento = await _orcamentoService.GetAsync(id);
            if (orcamento is null)
                return NotFound();

            updateOrcamento.Id = orcamento.Id;
            Orcamento updateOrcamento1 = updateOrcamento;
            await _orcamentoService.UpdateAsync(id, updateOrcamento1);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var orcamento = await _orcamentoService.GetAsync(id);
            if (orcamento is null)
                return NotFound();
            await _orcamentoService.DeleteAsync(id);
            return NoContent();
        }
    }

}
