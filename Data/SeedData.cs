static class SeedData
{
    public static async Task InicializarBD(ToDoListContext BD)
    {
        var listaTarefas = new List<Tarefa>() {
            new Tarefa {
                Id = 1,
                Nome = "Curso Angular",
                Descricao = "Um curso básico de Angular",
                DataInicio = DateTime.Now,
                Finalizada = false
            }, 
            new Tarefa {
                Id = 2,
                Nome = "Curso Blazor",
                Descricao = "Um curso básico de Blazor",
                DataInicio = DateTime.Now,
                Finalizada = false
            }
        };

        await BD.AddRangeAsync(listaTarefas);
        await BD.SaveChangesAsync();
    }
}