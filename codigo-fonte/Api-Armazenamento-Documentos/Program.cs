using Api_Orcamento.Models;
using Api_Orcamento.Service;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Api_Orcamento
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 🔧 Configurando acesso ao banco
            builder.Services.Configure<BudgetManagerDataBaseSettings>(
                builder.Configuration.GetSection("BudgetManagerDataBase"));

            // 🔧 Injeção dos serviços
            builder.Services.AddSingleton<SolicitacaoService>();
            builder.Services.AddSingleton<OrcamentoService>();
            builder.Services.AddSingleton<AutenticacaoService>();
            builder.Services.AddSingleton<ClienteService>();
            builder.Services.AddSingleton<FornecedorService>();
            builder.Services.AddSingleton<ProdutoService>();

            // 🔧 MVC e Razor
            builder.Services
                .AddControllersWithViews()
                .AddRazorRuntimeCompilation();

            // 🔐 Sessão
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // 🔧 Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // 🔧 Ambiente de desenvolvimento
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // 📦 Middlewares padrão
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // 🔐 Habilitando sessão
            app.UseSession();

            app.UseAuthorization();

            // 🧭 Rotas
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Autenticacao}/{action=Login}/{id?}");

            app.Run();
        }
    }
}