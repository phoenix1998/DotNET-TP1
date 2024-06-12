using SGE.UI.Components;
using SGE.Repositorios;
using SGE.Aplicacion;
using SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Servicios;
using SGE.Aplicacion.Validadores;
using Microsoft.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
// Add services to the container.
//  - Los nuestros

SgeContext contexto = new SgeContext(); //Vamos a compartir el
builder.Services.AddScoped<IServicioAutorizacion, ServicioAutorizacion>();
builder.Services.AddScoped<ServicioActualizacionEstado, ServicioActualizacionEstado>();
builder.Services.AddScoped<EspecificacionCambioEstado, EspecificacionCambioEstado>();
// Validadores (se cargan automáticamente en los casos de uso)

builder.Services.AddSingleton<ITramiteValidador, TramiteValidador>();
builder.Services.AddSingleton<IExpedienteValidador, ExpedienteValidador>();
builder.Services.AddSingleton<IUsuarioValidador, UsuarioValidador>();

// Casos de uso de Usuario
builder.Services.AddTransient<CasoDeUsoUsuarioAlta>();
builder.Services.AddTransient<CasoDeUsoUsuarioTienePermiso>();
builder.Services.AddTransient<CasoDeUsoUsuarioConsultaPorID>();
// Casos de uso de Expediente
builder.Services.AddTransient<CasoDeUsoExpedienteAlta>();
builder.Services.AddTransient<CasoDeUsoExpedienteBaja>();
builder.Services.AddTransient<CasoDeUsoExpedienteModificacion>();
builder.Services.AddTransient<CasoDeUsoExpedienteConsultaTodos>();
builder.Services.AddTransient<CasoDeUsoConsultaPorIdExpediente>();

// Casos de uso de Tramite
builder.Services.AddTransient<CasoDeUsoTramiteAlta>();
builder.Services.AddTransient<CasoDeUsoTramiteBaja>();
builder.Services.AddTransient<CasoDeUsoTramiteModificacion>();
builder.Services.AddTransient<CasoDeUsoTramiteConsultaPorEtiqueta>();
builder.Services.AddTransient<CasoDeUsoTramiteConsultaPorId>();

// Repositorios
builder.Services.AddSingleton<IUsuarioRepositorio, RepositorioUsuario>(usuRepo => new RepositorioUsuario(contexto));
builder.Services.AddSingleton<IExpedienteRepositorio, RepositorioExpediente>(expRepo => new RepositorioExpediente(contexto));
builder.Services.AddSingleton<ITramiteRepositorio, RepositorioTramite>(traRepo => new RepositorioTramite(contexto));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
