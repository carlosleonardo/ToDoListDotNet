using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ToDoListDotNet;
using BlazorBootstrap;
using Microsoft.EntityFrameworkCore;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazorBootstrap();
builder.Services.AddDbContextFactory<ToDoListContext>(options => {
    options.UseSqlite("Data Source=todo.db");
});
builder.Services.AddScoped<ServicoToDo>();

var app = builder.Build();
var escopoFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var escopo = escopoFactory.CreateScope())
{
    var db = escopo.ServiceProvider.GetRequiredService<ToDoListContext>();
    if (await db.Database.EnsureCreatedAsync())
    {
        await SeedData.InicializarBD(db);
    }
}

await app.RunAsync();
