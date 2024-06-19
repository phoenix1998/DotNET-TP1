using SGE.UI.Components;
using SGE.Repositorios;
using SGE.Aplicacion;
using SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Servicios;
using SGE.Aplicacion.Validadores;
using Microsoft.Extensions;
using SGE.Aplicacion.CasosDeUso.Expedientes;
using SGE.Aplicacion.CasosDeUso.Hash;
using SGE.Aplicacion.CasosDeUso.Tramites;
using SGE.Aplicacion.CasosDeUso.Usuarios;
using SGE.Aplicacion.CasosDeUso.Sesion;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
// Add services to the container.
//  - Los nuestros

SgeContext contexto = new SgeContext(); //Vamos a compartir el
IHasher hasher = new Hasher();
ISesion sesion = new Sesion();

builder.Services.AddScoped<IServicioAutorizacion, ServicioAutorizacion>();
builder.Services.AddScoped<ServicioActualizacionEstado, ServicioActualizacionEstado>();
builder.Services.AddScoped<EspecificacionCambioEstado, EspecificacionCambioEstado>();
builder.Services.AddScoped<ISesion, Sesion>();

// Validadores (se cargan automáticamente en los casos de uso)

builder.Services.AddSingleton<ITramiteValidador, TramiteValidador>();
builder.Services.AddSingleton<IExpedienteValidador, ExpedienteValidador>();
builder.Services.AddSingleton<IUsuarioValidador, UsuarioValidador>();

// Casos de uso de sesion
builder.Services.AddScoped<CasoDeUsoSesionEstado>();
builder.Services.AddScoped<CasoDeUsoSesionAlternar>();
builder.Services.AddScoped<CasoDeUsoUsuarioObtener>();
builder.Services.AddScoped<CasoDeUsoUsuarioCambiar>();

// Casos de uso de Usuario
builder.Services.AddTransient<CasoDeUsoUsuarioAlta>();
builder.Services.AddTransient<CasoDeUsoUsuarioConsultaPorID>();
builder.Services.AddTransient<CasoDeUsoUsuarioConsultaTodos>();
builder.Services.AddTransient<CasoDeUsoUsuarioModificar>();
builder.Services.AddTransient<CasoDeUsoUsuarioBaja>();

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

// Casos de uso de hash
builder.Services.AddTransient<CasoDeUsoObtenerHash>();
builder.Services.AddSingleton<IHasher, Hasher>();

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
