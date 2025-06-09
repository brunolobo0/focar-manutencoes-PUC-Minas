using Microsoft.AspNetCore.Mvc;
using Api_Orcamento.Service;
using Api_Orcamento.ViewModels;
using Api_Orcamento.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.ConstrainedExecution;

namespace Api_Orcamento.Controllers
{
    public class ClienteMvcController : Controller
    {
        private readonly ClienteService _clienteService;

        public ClienteMvcController(ClienteService clienteService)
            => _clienteService = clienteService;

        // LIST com pesquisa
        public async Task<IActionResult> Index(string termoBusca)
        {
            var clientes = await _clienteService.GetAllAsync();

            if (!string.IsNullOrWhiteSpace(termoBusca))
            {
                termoBusca = termoBusca.ToLower();
                clientes = clientes
                    .Where(s => s.Nome.ToLower().Contains(termoBusca)
                             || s.Email.ToLower().Contains(termoBusca)
                             || s.Telefone.ToLower().Contains(termoBusca)
                             || s.Endereco.ToLower().Contains(termoBusca)
                             || s.Complemento.ToLower().Contains(termoBusca)
                             || s.Cep.ToLower().Contains(termoBusca))
                    .ToList();
            }

            var viewModel = clientes.Select(s => new ClienteViewModel
            {
                Id = s.Id,
                Nome = s.Nome,
                Email = s.Email,
                Telefone = s.Telefone,
                Endereco = s.Endereco,
                Complemento = s.Complemento,
                Cep = s.Cep
            }).ToList();

            return View(viewModel);
        }

        // DETAILS
        public async Task<IActionResult> Details(string id)
        {
            var e = await _clienteService.GetAsync(id);
            if (e == null) return NotFound();
            var vm = new ClienteViewModel
            {
                Id = e.Id,
                Nome = e.Nome,
                Email = e.Email,
                Telefone = e.Telefone,
                Endereco = e.Endereco,
                Cep = e.Cep,
                Complemento = e.Complemento
            };
            return View(vm);
        }
        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClienteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newCliente = new Cliente
                {
                    Nome = model.Nome,
                    Email = model.Email,
                    Telefone = model.Telefone,
                    Endereco = model.Endereco,
                    Cep = model.Cep,
                    Complemento = model.Complemento
                };

                await _clienteService.CreateAsync(newCliente);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET EDIT
        public async Task<IActionResult> Edit(string id)
        {
            var cliente = await _clienteService.GetAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            var viewModel = new ClienteViewModel
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Telefone = cliente.Telefone,
                Endereco = cliente.Endereco,
                Cep = cliente.Cep,
                Complemento = cliente.Complemento
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, ClienteViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var cliente = await _clienteService.GetAsync(id);
                if (cliente == null)
                {
                    return NotFound();
                }

                cliente.Nome = model.Nome;
                cliente.Email = model.Email;
                cliente.Telefone = model.Telefone;
                cliente.Endereco = model.Endereco;
                cliente.Cep = model.Cep;
                cliente.Complemento = model.Complemento;
                await _clienteService.UpdateAsync(id, cliente);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET
        public async Task<IActionResult> Delete(string id)
        {
            var cliente = await _clienteService.GetAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            var viewModel = new ClienteViewModel
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
            };

            return View(viewModel);
        }

     
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cliente = await _clienteService.GetAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            await _clienteService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));  
        }
    }
}