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
TramiteValidador TV = new TramiteValidador();
IExpedienteRepositorio expRepo = new RepositorioExpediente(SA, EV);
ITramiteRepositorio traRepo = new RepositorioTramite(SA, TV);

// Programa
/*Expediente exp = new Expediente();
exp.IDExpediente = 1;
exp.Caratula = "Es una caratula";
exp.IDUser = 1;
exp.Estado = (EstadoExpediente)1;
expRepo.AltaExpediente(exp, (Permiso)3, 1);

Expediente exp2 = new Expediente();
exp2.IDExpediente = 2;
exp2.Caratula = "Es una caratula";
exp2.IDUser = 1;
exp2.Estado = (EstadoExpediente)1;
expRepo.AltaExpediente(exp2, (Permiso)3, 1);

Expediente exp3 = new Expediente();
exp3.IDExpediente = 3;
exp3.Caratula = "Es una caratula";
exp3.IDUser = 1;
exp3.Estado = (EstadoExpediente)1;
expRepo.AltaExpediente(exp3, (Permiso)3, 1);

//expRepo.BajaExpediente(exp, (Permiso)1, exp.IDUser);

Expediente expMod = new Expediente();
expMod.IDExpediente = 100;
expMod.Caratula = "Es el moificado";
expMod.IDUser = 1;
expMod.Estado = (EstadoExpediente)1;
expMod.FechaHoraCreacion = DateTime.Now;
expRepo.ModificacionExpediente(2, expMod, 1, (Permiso)1);
*/

Tramite tra = new Tramite();
tra.IDTramite = 1;
tra.expID = 1;
tra.EtiquetaTramite = (EtiquetaTramite)1;
tra.Contenido = "Esto es un tramite";
tra.IDUser = 1;
//traRepo.AltaTramite(tra, 1, (Permiso)1);

Tramite tra2 = new Tramite();
tra2.IDTramite = 2;
tra2.expID = 1;
tra2.EtiquetaTramite = (EtiquetaTramite)1;
tra2.Contenido = "Esto es un tramite";
tra2.IDUser = 1;
//traRepo.AltaTramite(tra2, 1, (Permiso)1);

Tramite tra3 = new Tramite();
tra3.IDTramite = 3;
tra3.expID = 2;
tra3.EtiquetaTramite = (EtiquetaTramite)1;
tra3.Contenido = "Esto es un tramite";
tra3.IDUser = 1;
//traRepo.AltaTramite(tra3, 1, (Permiso)1);

traRepo.BajaTramite(tra2.IDTramite, 1, (Permiso)1);

foreach (Tramite tram in traRepo.ConsultaPorEtiqueta((EtiquetaTramite)1))
{
    Console.WriteLine(tram);
}
