using Microsoft.AspNetCore.Mvc;
using Api_Orcamento.Service;
using Api_Orcamento.ViewModels;
using Api_Orcamento.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Api_Orcamento.ViewsModel;

namespace Api_Orcamento.Controllers
{
    public class FornecedorMvcController : Controller
    {
        private readonly FornecedorService _fornecedorService;

        public FornecedorMvcController(FornecedorService fornecedorService)
            => _fornecedorService = fornecedorService;

        // LIST com pesquisa
        public async Task<IActionResult> Index(string termoBusca)
        {
            var fornecedores = await _fornecedorService.GetAllAsync();

            if (!string.IsNullOrWhiteSpace(termoBusca))
            {
                termoBusca = termoBusca.ToLower();
                fornecedores = fornecedores
                    .Where(s => s.NomeFantasia.ToLower().Contains(termoBusca)
                             || s.RazaoSocial.ToLower().Contains(termoBusca)
                             || s.Cnpj.ToLower().Contains(termoBusca)
                             || s.InscricaoEstadual.ToLower().Contains(termoBusca)
                             || s.InscricaoMunicipal.ToLower().Contains(termoBusca)
                             || s.Telefone.ToLower().Contains(termoBusca)
                             || s.Email.ToLower().Contains(termoBusca)
                             || s.Observacoes.ToLower().Contains(termoBusca))
                    .ToList();
            }

            var viewModel = fornecedores.Select(s => new FornecedorViewModel
            {
                Id = s.Id,
                NomeFantasia = s.NomeFantasia,
                RazaoSocial = s.RazaoSocial,
                Cnpj = s.Cnpj,
                InscricaoEstadual = s.InscricaoEstadual,
                InscricaoMunicipal = s.InscricaoMunicipal,
                Telefone = s.Telefone,
                Email = s.Email,
                Observacoes = s.Observacoes,
            }).ToList();

            return View(viewModel);
        }


        // DETAILS
        public async Task<IActionResult> Details(string id)
        {
            var e = await _fornecedorService.GetAsync(id);
            if (e == null) return NotFound();
            var vm = new FornecedorViewModel
            {
                Id = e.Id,
                NomeFantasia = e.NomeFantasia,
                RazaoSocial = e.RazaoSocial,
                Cnpj = e.Cnpj,
                InscricaoEstadual = e.InscricaoEstadual,
                InscricaoMunicipal = e.InscricaoMunicipal,
                Email = e.Email,
                Telefone = e.Telefone,
                Observacoes = e.Observacoes
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
        public async Task<IActionResult> Create(FornecedorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newFornecedor = new Fornecedor
                {
                    NomeFantasia = model.NomeFantasia,
                    RazaoSocial = model.RazaoSocial,
                    Cnpj = model.Cnpj,
                    InscricaoEstadual = model.InscricaoEstadual,
                    InscricaoMunicipal = model.InscricaoMunicipal,
                    Email = model.Email,
                    Telefone = model.Telefone,
                    Observacoes = model.Observacoes

                };

                await _fornecedorService.CreateAsync(newFornecedor);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET EDIT
        public async Task<IActionResult> Edit (string id)
        {
            var fornecedor = await _fornecedorService.GetAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            var viewModel = new FornecedorViewModel
            {
                Id = fornecedor.Id,
                NomeFantasia = fornecedor.NomeFantasia,
                RazaoSocial = fornecedor.RazaoSocial,
                Cnpj = fornecedor.Cnpj,
                InscricaoEstadual = fornecedor.InscricaoEstadual,
                InscricaoMunicipal = fornecedor.InscricaoMunicipal,
                Email = fornecedor.Email,
                Telefone = fornecedor.Telefone,
                Observacoes = fornecedor.Observacoes
            };
            
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, FornecedorViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var fornecedor = await _fornecedorService.GetAsync(id);
                if (fornecedor == null)
                {
                    return NotFound();
                }

                fornecedor.NomeFantasia = model.NomeFantasia;
                fornecedor.RazaoSocial = model.RazaoSocial;
                fornecedor.Cnpj = model.Cnpj;
                fornecedor.InscricaoEstadual = model.InscricaoEstadual;
                fornecedor.InscricaoMunicipal = model.InscricaoMunicipal;
                fornecedor.Email = model.Email;
                fornecedor.Telefone = model.Telefone;
                fornecedor.Observacoes = model.Observacoes;
                await _fornecedorService.UpdateAsync(id, fornecedor);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET
        public async Task<IActionResult> Delete(string id)
        {
            var fornecedor = await _fornecedorService.GetAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            var viewModel = new FornecedorViewModel
            {
                Id = fornecedor.Id,
                NomeFantasia = fornecedor.NomeFantasia,
                Email = fornecedor.Email,
            };

            return View(viewModel);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var fornecedor = await _fornecedorService.GetAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            await _fornecedorService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}