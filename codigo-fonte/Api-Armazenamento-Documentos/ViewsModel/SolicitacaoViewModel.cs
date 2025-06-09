using System.ComponentModel.DataAnnotations;

namespace Api_Orcamento.ViewModels
{
    public class SolicitacaoViewModel
    {
        public string? Id { get; set; }

        public string Nome { get; set; } = "";

        public string? Descricao { get; set; } = "";

        public string Preco { get; set; } = "";

        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}