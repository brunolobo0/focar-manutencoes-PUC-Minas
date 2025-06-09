using System.ComponentModel.DataAnnotations;
using BCrypt.Net;

namespace Api_Orcamento.ViewsModel
{
    public class UsuarioViewModel
    {
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        public string Senha { get; set; } = string.Empty;

        public string HashSenha()
        {
            return BCrypt.Net.BCrypt.HashPassword(Senha);
        }
    }
}