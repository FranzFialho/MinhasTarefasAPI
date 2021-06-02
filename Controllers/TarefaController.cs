using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using MinhasTarefasAPI.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MinhasTarefasAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace MinhasTarefasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        public TarefaController(ITarefaRepository tarefaRepository, UserManager<ApplicationUser> userManager)
        {
            _tarefaRepository = tarefaRepository;
            _userManager = userManager;
        }

        [Authorize]
        [HttpPost("sincronizar")]
        public ActionResult Sincronizar([FromBody] List<Tarefa> tarefas)
        {
            return Ok(_tarefaRepository.Sincronizacao(tarefas));
        }

        [HttpGet("modelo")]
        public ActionResult Modelo()
        {
            return Ok(new Tarefa());
        }

        [Authorize]
        [HttpGet("restaurar")]
        public ActionResult Restaurar(DateTime data)
        {
            var usuario = _userManager.GetUserAsync(HttpContext.User).Result;



           return Ok ( _tarefaRepository.Restauracao(usuario, data));
        }
    }
}
