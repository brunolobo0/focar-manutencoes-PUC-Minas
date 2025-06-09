using Api_Orcamento.Models;
using Api_Orcamento.Service;
using Microsoft.AspNetCore.Mvc;

namespace Api_Orcamento.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuariosService _usuariosService;
        public UsuariosController(UsuariosService usuariosService)
        {
            _usuariosService = usuariosService;
        }
        [HttpGet]
        public async Task<List<Usuarios>> Get() =>
            await _usuariosService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Usuarios>> Get(string id)
        {
            var user = await _usuariosService.GetAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }
        [HttpPost]
        public async Task<IActionResult> Post(Usuarios newUser)
        {
            newUser.Id = null;

            await _usuariosService.CreateAsync(newUser);

            return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
        }
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Usuarios updateUser)
        {
            var user = await _usuariosService.GetAsync(id);
            if (user == null)
                return NotFound();
            updateUser.Id = user.Id;
            await _usuariosService.UpdateAsync(id, updateUser);
            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _usuariosService.GetAsync(id);
            if (user == null)
                return NotFound();
            await _usuariosService.RemoveAsync(id);
            return NoContent();
        }
    }
}