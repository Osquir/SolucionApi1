using BlazorCrud.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using BlazorCrud.Client.Services;
using CurrieTechnologies.Razor.SweetAlert2;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//URL DE CONEXION BACKEND AZURE = BaseAddress = new Uri("*****") 
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://calm-ocean-015de1a10.3.azurestaticapps.net") });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7027/") });
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("") });

builder.Services.AddScoped<IAlumnoCursoService, AlumnoCursoServices>();
builder.Services.AddScoped<ICursoService, CursoService>();
builder.Services.AddScoped<IAlumnoService, AlumnoService>();

builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();
