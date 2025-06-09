using Api_Orcamento.Models;
using Api_Orcamento.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Orcamento.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        [HttpGet]
        public async Task<List<Cliente>> Get() =>
            await _clienteService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Cliente>> Get(string id)
        {
            var cliente = await _clienteService.GetAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }
            return cliente;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Cliente newCliente)
        {
            newCliente.Id = null;

            await _clienteService.CreateAsync(newCliente);

            return CreatedAtAction(nameof(Get), new { id = newCliente.Id }, newCliente);
        }
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Cliente updateCliente)
        {
            var cliente = await _clienteService.GetAsync(id);
            if (cliente is null)
                return NotFound();

            updateCliente.Id = cliente.Id;
            Cliente updateOrcamento1 = updateCliente;
            await _clienteService.UpdateAsync(id, updateCliente);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var cliente = await _clienteService.GetAsync(id);
            if (cliente is null)
                return NotFound();
            await _clienteService.DeleteAsync(id);
            return NoContent();
        }
    }
}