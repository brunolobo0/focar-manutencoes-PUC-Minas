using System.ComponentModel.DataAnnotations;

namespace Api_Orcamento.ViewModels
{
    public class ProdutoViewModel
    {
        public string? Id { get; set; }

        [Required]
        public string NomeProduto { get; set; } = "";

        [Required]
        public string Marca { get; set; } = "";

        [Required]
        public string? Descricao { get; set; } = "";

    }
}