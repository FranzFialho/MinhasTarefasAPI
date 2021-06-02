using System.ComponentModel.DataAnnotations;

namespace MinhasTarefasAPI.Models
{
    public class UsuarioDTO
    {
        [Required(ErrorMessage ="Nome Obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email obrigatório")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha obrigatória")]  
        public string Senha { get; set; }

        [Required]
        [Compare("Senha")]// Irá comparar se ConfirmacaoSenha é igual a Senha.
        public string ConfirmacaoSenha  { get; set; }

    }
}
