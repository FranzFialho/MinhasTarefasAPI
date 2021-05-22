using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MinhasTarefasAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }

        [ForeignKey("UsuarioId")]//Tarefas esta vinculado ao UsuarioId, da classe Tarefa
        public virtual IEnumerable<Tarefa> Tarefas { get; set; }

    }
}
