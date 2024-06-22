using Microsoft.AspNetCore.Mvc;
using Noonsoft.Entities;
using Noonsoft.interfaces;

namespace Noonsoft.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {
        private  List<Tarefa> tarefas = new List<Tarefa>();

        private readonly ILogger<TarefasController> _logger;
        private readonly ITarefaService _tarefaService;
        public TarefasController(ILogger<TarefasController> logger, ITarefaService tarefaService)
        {
            _logger = logger;
            _tarefaService = tarefaService;
        }

        [HttpGet(Name = "tarefas")]
        public IEnumerable<Tarefa> Get()
        {
            return _tarefaService.GetTarefas();
        }

        [Route("{id}")]
        [HttpGet]
        public Tarefa GetTarefa([FromRoute] int id)
        {
           return _tarefaService.GetTarefa(id);
        }

        [HttpPost(Name = "tarefas")]

        public IActionResult Post([FromBody] Tarefa tarefa)
        {
            if(tarefa.titulo == "" || tarefa.objetivo == "")
            {
                return BadRequest("titulo e objetivo são obrigatórios");
            }

            tarefa.concluida = false;
            _tarefaService.AddTarefa(tarefa);
            return Ok("tarefa inserida com sucesso");
        }

        [Route("{id}")]
        [HttpDelete]
        public void Delete([FromRoute] int id)
        {
            _tarefaService.RemoveTarefa(id);
        }

        [Route("{id}")]
        [HttpPut]
        public IActionResult Put([FromRoute] int id, [FromBody] Tarefa tarefa)
        {

            if (tarefa.titulo == "" || tarefa.objetivo == "")
            {
                return BadRequest("titulo e objetivo são obrigatórios");
            }

            _tarefaService.UpdateTarefa(id, tarefa);

            return Ok("Tarefa atualizada com sucesso!");
        }

        [Route("concluidas")]
        [HttpGet]
        public IEnumerable<Tarefa> GetConcluidas()
        {
           return _tarefaService.GetTarefasConcluidas();
        }

        [Route("concluidas/{id}")]
        [HttpPut]
        public void PutTarefaConcluida([FromRoute] int id)
        {
            _tarefaService.UpdateTarefaConcluida(id);
        }
    }
}
