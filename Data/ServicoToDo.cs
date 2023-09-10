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

    public async Task AlterarTarefa(Tarefa tarefa)
    {
        toDoListContext.Update(tarefa);
        await toDoListContext.SaveChangesAsync();
    }

    public async Task<Tarefa?> ObterTarefa(int id)
    {
        return await toDoListContext.Tarefas!.FindAsync(id);
    }

    public async Task ExcluirTarefa(Tarefa tarefa)
    {
        toDoListContext.Tarefas?.Remove(tarefa);
        await toDoListContext.SaveChangesAsync();
    }

    public async Task<IList<Tarefa>> ObterTarefas()
    {
        return await toDoListContext.Tarefas!.ToListAsync<Tarefa>();
    }
}