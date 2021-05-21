using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MinhasTarefasAPI.Models;

namespace MinhasTarefasAPI.Context
{
    public class MinhasTarefasContext : DbContext
    {
        public MinhasTarefasContext(DbContextOptions<MinhasTarefasContext> options) 
            :base(options)
        {
           
        }

        public DbSet<Tarefa> Tarefas { get; set; }

    }
}
