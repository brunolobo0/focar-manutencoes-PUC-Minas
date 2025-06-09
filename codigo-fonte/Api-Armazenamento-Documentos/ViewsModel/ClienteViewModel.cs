using System.ComponentModel.DataAnnotations;

namespace Api_Orcamento.ViewModels
{
    public class ClienteViewModel
    {
        public string? Id { get; set; }

        [Required]
        public string Nome { get; set; } = "";

        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        public string Telefone { get; set; } = "";

        [Required]
        public string Endereco { get; set; } = "";

        [Required]
        public string? Complemento { get; set; } = "";

        [Required]
        public string Cep { get; set; } = "";
    }
}
