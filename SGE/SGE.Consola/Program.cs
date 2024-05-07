using SGE.Aplicacion.CasosDeUso;
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

//Casos de usos
CasoDeUsoExpedienteAlta CUExpAlta = new CasoDeUsoExpedienteAlta(expRepo);
CasoDeUsoExpedienteBaja CUExpBaja = new CasoDeUsoExpedienteBaja(expRepo);
CasoDeUsoExpedienteConsultaTodos CUConTodos = new CasoDeUsoExpedienteConsultaTodos(expRepo);
CasoDeUsoExpedienteModificacion CUMod = new CasoDeUsoExpedienteModificacion(expRepo);
CasoDeUsoTramiteAlta CUTraAlta = new CasoDeUsoTramiteAlta(traRepo);
CasoDeUsoTramiteBaja CUTraBaja = new CasoDeUsoTramiteBaja(traRepo);
CasoDeUsoTramiteConsultaPorEtiqueta CUTraConEti = new CasoDeUsoTramiteConsultaPorEtiqueta(traRepo);
CasoDeUsoTramiteConsultaPorIdExpediente idExp = new CasoDeUsoTramiteConsultaPorIdExpediente(traRepo, expRepo);
CasoDeUsoTramiteModificacion CUTraMod = new CasoDeUsoTramiteModificacion(traRepo);


// Programa
Expediente exp1 = new Expediente();
exp1.IDExpediente = 1;
exp1.Caratula = "Es una caratula";
exp1.Estado = (EstadoExpediente)1;
exp1.IDUser = 1;
//expRepo.AltaExpediente(exp1, (Permiso)1, 1);
CUExpAlta.Ejecutar(exp1, (Permiso)1, 1);

Expediente exp2 = new Expediente();
exp2.IDExpediente = 2;
exp2.Caratula = "Es una caratula 2";
exp2.Estado = (EstadoExpediente)2;
exp2.IDUser = 2;
//expRepo.AltaExpediente(exp2, (Permiso)1, 1);
CUExpAlta.Ejecutar(exp2, (Permiso)1, 1);

Expediente exp3 = new Expediente();
exp3.IDExpediente = 3;
exp3.Caratula = "Es una caratula 3";
exp3.Estado = (EstadoExpediente)3;
exp3.IDUser = 3;
//expRepo.AltaExpediente(exp3, (Permiso)1, 1);
CUExpAlta.Ejecutar(exp3, (Permiso)1, 1);

// Tramites
Tramite tra1 = new Tramite();
tra1.IDTramite = 1;
tra1.expID = 1;
tra1.EtiquetaTramite = (EtiquetaTramite)1;
tra1.Contenido = "Esto es un tramite";
tra1.IDUser = 1;
//traRepo.AltaTramite(tra1, 1, (Permiso)1);
CUTraAlta.Ejercutar(tra1, 1, (Permiso)1);

Tramite tra2 = new Tramite();
tra2.IDTramite = 2;
tra2.expID = 1;
tra2.EtiquetaTramite = (EtiquetaTramite)2;
tra2.Contenido = "Esto es un tramite 2";
tra2.IDUser = 2;
//traRepo.AltaTramite(tra2, 1, (Permiso)1);
CUTraAlta.Ejercutar(tra1, 1, (Permiso)1);

Tramite tra3 = new Tramite();
tra3.IDTramite = 3;
tra3.expID = 1;
tra3.EtiquetaTramite = (EtiquetaTramite)3;
tra3.Contenido = "Esto es un tramite 3";
tra3.IDUser = 3;
//traRepo.AltaTramite(tra3, 1, (Permiso)1);
CUTraAlta.Ejercutar(tra1, 1, (Permiso)1);

// Consultar por Todos los expediente


/*foreach (Expediente exp in expRepo.ConsultarTodos())
{
    Console.WriteLine(exp);
}*/


//Console.WriteLine(expRepo.ConsultaPorID(3));
Expediente exp4 = idExp.Ejecutar(1);
Console.WriteLine(exp4);
foreach (Tramite tra in exp4.Tramites)
{
    Console.WriteLine(tra);
}
