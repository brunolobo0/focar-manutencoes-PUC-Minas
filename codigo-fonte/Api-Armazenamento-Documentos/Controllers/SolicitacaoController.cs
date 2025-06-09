using Api_Orcamento.Models;
using Api_Orcamento.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Orcamento.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class SolicitacaoController : ControllerBase
    {
        private readonly SolicitacaoService _solicitacaoService;

        public SolicitacaoController(SolicitacaoService docsService)
        {
            _solicitacaoService = docsService;
        }

        [HttpGet]
        public async Task<List<Models.Solicitacao>> Get() =>
            await _solicitacaoService.GetAsync();

        [HttpGet("{Id:length(24)}")]
        public async Task<ActionResult<Models.Solicitacao>> Get(string id)
        {
            var budgetStorage = await _solicitacaoService.GetAsync(id);
            if (budgetStorage == null)
            {
                return NotFound();
            }
            return budgetStorage;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Models.Solicitacao newDocuments)
        {
            newDocuments.Id = null;

            await _solicitacaoService.CreateAsync(newDocuments);

            return CreatedAtAction(nameof(Get), new { id = newDocuments.Id }, newDocuments);
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var budgetStorage = await _solicitacaoService.GetAsync(id);
            if (budgetStorage is null)
                return NotFound();
            await _solicitacaoService.DeleteAsync(id);
            return NoContent();
        }
    }
}
