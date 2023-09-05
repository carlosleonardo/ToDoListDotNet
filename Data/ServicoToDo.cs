using Microsoft.EntityFrameworkCore;

public class ServicoToDo
{
    private ToDoListContext toDoListContext;
    public ServicoToDo(ToDoListContext toDoListContext)
    {
        this.toDoListContext = toDoListContext;
    }

    public async Task AdicionarTarefa(Tarefa tarefa)
    {
        toDoListContext.Tarefas?.Add(tarefa);
        await toDoListContext.SaveChangesAsync();
    }

    public async Task<IList<Tarefa>> ObterTarefas()
    {
        return await toDoListContext.Tarefas!.ToListAsync<Tarefa>();
    }
}