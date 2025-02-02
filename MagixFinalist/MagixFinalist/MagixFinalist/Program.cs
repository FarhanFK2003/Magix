using MagixFinalist.Client.Pages;
using MagixFinalist.Components;
using MagixFinalist.Models;
using MagixFinalist.Repositories;
using MagixFinalist.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MagixDB;Integrated Security=True;";

// Register custom services
builder.Services.AddScoped<IMovieRepository>(sp => new MovieRepository(connectionString));
builder.Services.AddScoped<MoviesService>();
builder.Services.AddScoped<ICustomerRepository>(sp => new CustomerRepository(connectionString));
builder.Services.AddScoped<CustomersService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(MagixFinalist.Client._Imports).Assembly);

app.Run();
