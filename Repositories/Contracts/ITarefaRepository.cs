using MinhasTarefasAPI.Models;
using System;
using System.Collections.Generic;

namespace MinhasTarefasAPI.Repositories.Contracts
{
    public interface ITarefaRepository
    {

        List<Tarefa> Sincronizacao(List<Tarefa> tarefas);
        List<Tarefa> Restauracao(ApplicationUser UsuarioId, DateTime dataUltimaSicronizacao);

    }
}
