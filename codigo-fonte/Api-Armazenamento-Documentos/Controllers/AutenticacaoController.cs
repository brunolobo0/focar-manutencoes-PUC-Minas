using Microsoft.AspNetCore.Mvc;
using Api_Orcamento.Models;
using Api_Orcamento.ViewsModel;
using Api_Orcamento.Service;
using Microsoft.AspNetCore.Http;

namespace Api_Orcamento.Controllers
{
    public class AutenticacaoController : Controller
    {
        private readonly AutenticacaoService _autenticacaoService;

        public AutenticacaoController(AutenticacaoService autenticacaoService)
        {
            _autenticacaoService = autenticacaoService;
        }

        public IActionResult Login() => View();

        public IActionResult Registrar() => View();

        [HttpPost]
        public async Task<IActionResult> Login(UsuarioViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.Senha))
            {
                ModelState.AddModelError(string.Empty, "Email e senha são obrigatórios.");
                return View(model);
            }

            if (!ModelState.IsValid)
                return View(model);

            var usuarios = await _autenticacaoService.GetAllAsync();
            var usuario = usuarios.FirstOrDefault(u => u.Email == model.Email);

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(model.Senha, usuario.Senha))
            {
                ModelState.AddModelError(string.Empty, "Email ou senha inválidos.");
                return View(model);
            }

            HttpContext.Session.SetString("UsuarioEmail", usuario.Email);
            HttpContext.Session.SetString("UsuarioPerfil", usuario.Perfil ?? "");

            return RedirectToAction("Index", "OrcamentoMvc");
        }


        [HttpPost]
        public async Task<IActionResult> Registrar(UsuarioViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var usuarios = await _autenticacaoService.GetAllAsync();
            var usuarioExistente = usuarios.FirstOrDefault(u => u.Email == model.Email);

            if (usuarioExistente != null)
            {
                ModelState.AddModelError("", "Já existe um usuário com esse e-mail");
                return View(model);
            }

            var novoUsuario = new Usuarios
            {
                Email = model.Email,
                Senha = model.HashSenha(), // Criptografa a senha antes de salvar
                Nome = model.Nome,
                Perfil = "Comum"
            };

            await _autenticacaoService.CreateAsync(novoUsuario);

            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}