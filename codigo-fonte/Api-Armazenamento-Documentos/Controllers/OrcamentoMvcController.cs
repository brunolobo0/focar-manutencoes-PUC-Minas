using Microsoft.AspNetCore.Mvc;
using Api_Orcamento.Service;
using Api_Orcamento.ViewModels;
using Api_Orcamento.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;

namespace Api_Orcamento.Controllers
{
    public class OrcamentoMvcController : Controller
    {
        private readonly OrcamentoService _orcamentoService;

        public OrcamentoMvcController(OrcamentoService orcamentoService)
            => _orcamentoService = orcamentoService;

        // LIST com pesquisa
        public async Task<IActionResult> Index(string termoBusca)
        {
            var orcamentos = await _orcamentoService.GetAllAsync();

            if (!string.IsNullOrWhiteSpace(termoBusca))
            {
                termoBusca = termoBusca.ToLower();
                orcamentos = orcamentos
                    .Where(s => s.Nome.ToLower().Contains(termoBusca)
                             || s.Email.ToLower().Contains(termoBusca)
                             || s.Telefone.ToLower().Contains(termoBusca)
                             || s.Detalhes.ToLower().Contains(termoBusca))
                    .ToList();
            }

            var viewModel = orcamentos.Select(s => new OrcamentoViewModel
            {
                Id = s.Id,
                Nome = s.Nome,
                Email = s.Email,
                Telefone = s.Telefone,
                Detalhes = s.Detalhes,
                DataCriacao = s.DataCriacao,
                DataAtualizacao = s.DataAtualizacao
            }).ToList();

            return View(viewModel);
        }

        // DETAILS
        public async Task<IActionResult> Details(string id)
        {
            var e = await _orcamentoService.GetAsync(id);
            if (e == null) return NotFound();
            var vm = new OrcamentoViewModel
            {
                Id = e.Id,
                Nome = e.Nome,
                Email = e.Email,
                Telefone = e.Telefone,
                Detalhes = e.Detalhes,
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
        public async Task<IActionResult> Create(OrcamentoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var brazilZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
                var dataCriacaoFixa = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, brazilZone);
                var newOrcamento = new Orcamento
                {
                    Nome = model.Nome,
                    Email = model.Email,
                    Telefone = model.Telefone,
                    Detalhes = model.Detalhes,
                    DataCriacao = dataCriacaoFixa // Usando a variável armazenada
                };

                await _orcamentoService.CreateAsync(newOrcamento);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET EDIT
        public async Task<IActionResult> Edit(string id)
        {
            var orcamento = await _orcamentoService.GetAsync(id);
            if (orcamento == null)
            {
                return NotFound();
            }

            var viewModel = new OrcamentoViewModel
            {
                Id = orcamento.Id,
                Nome = orcamento.Nome,
                Email = orcamento.Email,
                Telefone = orcamento.Telefone,
                Detalhes = orcamento.Detalhes
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, OrcamentoViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var brazilZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
                var dataCriacaoFixa = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, brazilZone);
                var orcamento = await _orcamentoService.GetAsync(id);
                if (orcamento == null)
                    return NotFound();

                orcamento.Nome = model.Nome;
                orcamento.Email = model.Email;
                orcamento.Telefone = model.Telefone;
                orcamento.Detalhes = model.Detalhes;
                orcamento.DataAtualizacao = dataCriacaoFixa; // ← Aqui

                await _orcamentoService.UpdateAsync(id, orcamento);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET
        public async Task<IActionResult> Delete(string id)
        {
            var orcamento = await _orcamentoService.GetAsync(id);
            if (orcamento == null)
            {
                return NotFound();
            }

            var viewModel = new OrcamentoViewModel
            {
                Id = orcamento.Id,
                Nome = orcamento.Nome,
                Email = orcamento.Email,
            };

            return View(viewModel);
        }

     
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var orcamento = await _orcamentoService.GetAsync(id);
            if (orcamento == null)
            {
                return NotFound();
            }

            await _orcamentoService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));  
        }



    }
}
