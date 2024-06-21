using Noonsoft.Entities;
using Noonsoft.interfaces;
using System.Runtime;

namespace Noonsoft.services
{
    public class TarefaService : ITarefaService
    {
        private  List<Tarefa> _tarefas = new List<Tarefa>();
        private int id = 0;

        public IEnumerable<Tarefa> GetTarefas()
        {
            var tarefasParaFazerConcluidas = _tarefas.Where(t => t.concluida == false).ToList();

            return tarefasParaFazerConcluidas;
        }

        public Tarefa GetTarefa(int id)
        {
             Tarefa tarefa = _tarefas.First(t => t.id == id);

            return tarefa;
        }


        public IEnumerable<Tarefa> GetTarefasConcluidas()
        {
            var tarefasConcluidas = _tarefas.Where(t => t.concluida == true).ToList();

            return tarefasConcluidas;
        }

        public void AddTarefa(Tarefa tarefa)
        {
            tarefa.id = ++id;

            _tarefas.Add(tarefa);
        }

        public void RemoveTarefa(int id)
        {
            Tarefa tarefa = _tarefas.First(t => t.id == id);
            if (tarefa != null)
            {
                _tarefas.Remove(tarefa);
            }
        }

        public void UpdateTarefa(int id, Tarefa tarefa)
        {
            var t = _tarefas.FirstOrDefault(t => t.id == id);
            if (t != null)
            {
                t.titulo = tarefa.titulo;
                t.objetivo = tarefa.objetivo;
                // atualize outros campos conforme necessário...
            }
        }

        public void UpdateTarefaConcluida(int id)
        {
            var t = _tarefas.FirstOrDefault(t => t.id == id);
            if (t != null)
            {
                t.concluida = true;
                // atualize outros campos conforme necessário...
            }
        }


    }
}
