using Api_Orcamento.Models;
using Api_Orcamento.Service;
using Api_Orcamento.ViewModels;
using Api_Orcamento.ViewsModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Orcamento.Controllers
{
    public class SolicitacaoMvcController : Controller
    {
        private readonly SolicitacaoService _solicitacaoService;

        public SolicitacaoMvcController(SolicitacaoService solicitacaoService)
            => _solicitacaoService = solicitacaoService;


        // LIST com pesquisa
        public async Task<IActionResult> Index(string termoBusca)
        {
            var solicitacoes = await _solicitacaoService.GetAllAsync();

            if (!string.IsNullOrWhiteSpace(termoBusca))
            {
                termoBusca = termoBusca.ToLower();
                solicitacoes = solicitacoes
                    .Where(s => s.Nome.ToLower().Contains(termoBusca)
                             || s.Preco.ToLower().Contains(termoBusca)
                             || s.Descricao.ToLower().Contains(termoBusca))
                    .ToList();
            }

            var viewModel = solicitacoes.Select(s => new SolicitacaoViewModel
            {
                Id = s.Id,
                Nome = s.Nome,
                Preco = s.Preco,
                Descricao = s.Descricao,
                DataCriacao = s.DataCriacao,
                DataAtualizacao = s.DataAtualizacao
            }).ToList();

            return View(viewModel);
        }

        // DETAILS
        public async Task<IActionResult> Details(string id)
        {
            var e = await _solicitacaoService.GetAsync(id);
            if (e == null) return NotFound();
            var vm = new SolicitacaoViewModel
            {
                Id = e.Id,
                Nome = e.Nome,
                Preco = e.Preco,
                Descricao = e.Descricao,
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
        public async Task<IActionResult> Create(SolicitacaoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var brazilZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
                var dataCriacaoFixa = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, brazilZone);
                var newSolicitacao = new Solicitacao

                {
                    Nome = model.Nome,
                    Preco = model.Preco,
                    Descricao = model.Descricao,
                    DataCriacao = dataCriacaoFixa // Usando a variável armazenada
                };

                await _solicitacaoService.CreateAsync(newSolicitacao);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET EDIT
        public async Task<IActionResult> Edit(string id)
        {
            var solicitacao = await _solicitacaoService.GetAsync(id);
            if (solicitacao == null)
            {
                return NotFound();
            }

            var viewModel = new SolicitacaoViewModel
            {
                Id = solicitacao.Id,
                Nome = solicitacao.Nome,
                Preco = solicitacao.Preco,
                Descricao = solicitacao.Descricao
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, SolicitacaoViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var brazilZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
                var dataCriacaoFixa = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, brazilZone);
                var solicitacao = await _solicitacaoService.GetAsync(id);
                if (solicitacao == null)
                {
                    return NotFound();
                }

                solicitacao.Nome = model.Nome;
                solicitacao.Preco = model.Preco;
                solicitacao.Descricao = model.Descricao;
                solicitacao.DataAtualizacao = dataCriacaoFixa; // ← Aqui
                await _solicitacaoService.UpdateAsync(id, solicitacao);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET
        public async Task<IActionResult> Delete(string id)
        {
            var solicitacao = await _solicitacaoService.GetAsync(id);
            if (solicitacao == null)
            {
                return NotFound();
            }

            var viewModel = new SolicitacaoViewModel
            {
                Id = solicitacao.Id,
                Nome = solicitacao.Nome,
                Preco = solicitacao.Preco,
                Descricao = solicitacao.Descricao,
            };

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cliente = await _solicitacaoService.GetAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            await _solicitacaoService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}