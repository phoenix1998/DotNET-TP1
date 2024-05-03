using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Servicios;
using SGE.Aplicacion.Validadores;
using SGE.Repositorios;
// Config de dependencias
IServicioAutorizacion SA = new ServicioAutorizacionProvisorio();
ExpedienteValidador EV = new ExpedienteValidador();
IExpedienteRepositorio expRepo = new RepositorioExpediente(SA, EV);

// Programa
Expediente exp = new Expediente();
exp.IDExpediente = 1;
exp.Caratula = "Es una caratula";
exp.IDUser = 1;
exp.Estado = (EstadoExpediente)1;
expRepo.AltaExpediente(exp, (Permiso)3, 1);
expRepo.BajaExpediente(exp, (Permiso)1, exp.IDUser);
