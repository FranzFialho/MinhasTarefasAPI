using MinhasTarefasAPI.Context;
using MinhasTarefasAPI.Models;
using MinhasTarefasAPI.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhasTarefasAPI.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly MinhasTarefasContext _banco;

        public TarefaRepository(MinhasTarefasContext banco)
        {
            _banco = banco;
        }

        public List<Tarefa> Restauracao(ApplicationUser usuario, DateTime dataUltimaSicronizacao)
        {
            var query = _banco.Tarefas.Where(a => a.UsuarioId == usuario.Id).AsQueryable();

            if (dataUltimaSicronizacao != null)
            {
                query.Where(a => a.Criado >= dataUltimaSicronizacao || a.Atualizado >= dataUltimaSicronizacao);
            }

            return query.ToList<Tarefa>();

        }

        public List<Tarefa> Sincronizacao(List<Tarefa> tarefas)
        {

            var TarefasNovas = tarefas.Where(a => a.IdTarefaApi == 0);
            //Cadastrar Novos Registros
            if(TarefasNovas.Count() > 0)
            {
                foreach(var tarefa in TarefasNovas)
                {
                    _banco.Tarefas.Add(tarefa);
                }
            }

            var TarefasExcluidasAtualizadas = tarefas.Where(a => a.IdTarefaApi != 0);
            //Atualização de registro ( Excluido )
            if (TarefasExcluidasAtualizadas.Count() > 0)
            {
                foreach (var tarefa in TarefasExcluidasAtualizadas)
                {
                    _banco.Tarefas.Update(tarefa);
                }
            }

            _banco.SaveChanges();

            return TarefasNovas.ToList();
        }
    }
}
