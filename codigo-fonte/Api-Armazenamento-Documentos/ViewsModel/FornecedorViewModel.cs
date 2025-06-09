using System.ComponentModel.DataAnnotations;

namespace Api_Orcamento.ViewsModel
{
    public class FornecedorViewModel
    {
        public string? Id {get; set;}

        [Required]
        public string NomeFantasia { get; set; } = "";

        [Required]
        public string RazaoSocial { get; set; } = "";
        
        [Required]
        public string Cnpj { get; set; } = "";

        public string InscricaoEstadual { get; set; } = "";

        public string InscricaoMunicipal { get; set; } = "";

        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        public string Telefone { get; set; } = "";

        public string Observacoes { get; set; } = "";
        
    }
}
