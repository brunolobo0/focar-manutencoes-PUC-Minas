using Api_Orcamento.Models;
using Api_Orcamento.Service;
using Api_Orcamento.ViewModels;
using Api_Orcamento.ViewsModel;
using Microsoft.AspNetCore.Mvc;

namespace Api_Orcamento.Controllers
{
    public class ProdutoMvcController : Controller
    {

        private readonly ProdutoService _produtoService;

        public ProdutoMvcController(ProdutoService produtoService)
            => _produtoService = produtoService;

        // LIST com pesquisa
        public async Task<IActionResult> Index(string termoBusca)
        {
            var produtos = await _produtoService.GetAllAsync();

            if (!string.IsNullOrWhiteSpace(termoBusca))
            {
                termoBusca = termoBusca.ToLower();
                produtos = produtos
                    .Where(s => s.NomeProduto.ToLower().Contains(termoBusca)
                             || s.Marca.ToLower().Contains(termoBusca)
                             || s.Descricao.ToLower().Contains(termoBusca))
                    .ToList();
            }

            var viewModel = produtos.Select(s => new ProdutoViewModel
            {
                Id = s.Id,
                NomeProduto = s.NomeProduto,
                Marca = s.Marca,
                Descricao = s.Descricao,
            }).ToList();

            return View(viewModel);
        }

        // DETAILS
        public async Task<IActionResult> Details(string id)
        {
            var e = await _produtoService.GetAsync(id);
            if (e == null) return NotFound();
            var vm = new ProdutoViewModel
            {
                Id = e.Id,
                NomeProduto = e.NomeProduto,
                Marca = e.Marca,
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
        public async Task<IActionResult> Create(ProdutoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newProduto = new Produto
                {
                    NomeProduto = model.NomeProduto,
                    Marca = model.Marca,
                    Descricao = model.Descricao
                };

                await _produtoService.CreateAsync(newProduto);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET EDIT
        public async Task<IActionResult> Edit(string id)
        {
            var produto = await _produtoService.GetAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            var viewModel = new ProdutoViewModel
            {
                Id = produto.Id,
                NomeProduto = produto.NomeProduto,
                Marca = produto.Marca,
                Descricao = produto.Descricao
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, ProdutoViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var produto = await _produtoService.GetAsync(id);
                if (produto == null)
                {
                    return NotFound();
                }

                produto.NomeProduto = model.NomeProduto;
                produto.Marca = model.Marca;
                produto.Descricao = model.Descricao;
                await _produtoService.UpdateAsync(id, produto);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET
        public async Task<IActionResult> Delete(string id)
        {
            var produto = await _produtoService.GetAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            var viewModel = new ProdutoViewModel
            {
                Id = produto.Id,
                NomeProduto = produto.NomeProduto,
                Marca = produto.Marca,
                Descricao = produto.Descricao,
            };

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var produto = await _produtoService.GetAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            await _produtoService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}