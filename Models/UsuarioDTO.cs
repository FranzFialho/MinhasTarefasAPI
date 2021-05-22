using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinhasTarefasAPI.Models
{
    public class UsuarioDTO
    {
        [Required(ErrorMessage ="Nome Obrigatório")]
        public string Nome { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="Email Inválido")]
        public string Email { get; set; }

        [Required]  
        public string Senha { get; set; }

        [Required]
        [Compare("Senha")]// Irá comparar se ConfirmacaoSenha é igual a Senha.
        public string ConfirmacaoSenha  { get; set; }

    }
}
