using Microsoft.EntityFrameworkCore;

public class ToDoListContext : DbContext
{
    public DbSet<Tarefa>? Tarefas {get; set; }
    
    public ToDoListContext(DbContextOptions<DbContext> options):base(options)
    {
        
    }
}