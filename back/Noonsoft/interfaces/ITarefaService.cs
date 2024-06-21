using Noonsoft.Entities;

namespace Noonsoft.interfaces
{
    public interface ITarefaService
    {
        IEnumerable<Tarefa> GetTarefas();
        Tarefa GetTarefa(int id);

        IEnumerable<Tarefa> GetTarefasConcluidas();
        void AddTarefa(Tarefa tarefa);

        void RemoveTarefa(int id);

        void UpdateTarefa(int id, Tarefa tarefa);

        void UpdateTarefaConcluida(int id);

    }
}
