using System.ComponentModel.DataAnnotations;

namespace Api_Orcamento.ViewModels
{
    public class OrcamentoViewModel
    {
        public string? Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Telefone { get; set; } = null!;
        public string? Detalhes { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
