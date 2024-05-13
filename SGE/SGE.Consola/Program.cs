﻿using SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Servicios;
using SGE.Aplicacion.Validadores;
using SGE.Repositorios;
using System.Diagnostics.Contracts;


// Config de dependencias
IServicioAutorizacion SA = new ServicioAutorizacionProvisorio();
ExpedienteValidador EV = new ExpedienteValidador();
TramiteValidador TV = new TramiteValidador();
IExpedienteRepositorio expRepo = new RepositorioExpediente();
ITramiteRepositorio traRepo = new RepositorioTramite();
ServicioActualizacionEstado updater = new ServicioActualizacionEstado();

//Casos de usos
CasoDeUsoExpedienteAlta CUExpAlta = new CasoDeUsoExpedienteAlta(expRepo);
CasoDeUsoExpedienteBaja CUExpBaja = new CasoDeUsoExpedienteBaja(expRepo, traRepo);
CasoDeUsoExpedienteConsultaTodos CUConTodos = new CasoDeUsoExpedienteConsultaTodos(expRepo);
CasoDeUsoExpedienteModificacion CUMod = new CasoDeUsoExpedienteModificacion(expRepo);
CasoDeUsoTramiteAlta CUTraAlta = new CasoDeUsoTramiteAlta(traRepo, expRepo, updater);
CasoDeUsoTramiteBaja CUTraBaja = new CasoDeUsoTramiteBaja(traRepo, updater, expRepo);
CasoDeUsoTramiteConsultaPorEtiqueta CUTraConEti = new CasoDeUsoTramiteConsultaPorEtiqueta(traRepo);
CasoDeUsoTramiteConsultaPorIdExpediente CUTidExp = new CasoDeUsoTramiteConsultaPorIdExpediente(traRepo, expRepo);
CasoDeUsoTramiteModificacion CUTraMod = new CasoDeUsoTramiteModificacion(traRepo, updater, expRepo);

// Programa
//Las operaciones de alta y baja del repositorio se encargan de las fechas y del ID, así que solo le pasamos la caratula, el ID de usuario y el Estado
// - EXPEDIENTES
Expediente exp1 = new Expediente("Es una caratula", 1, (EstadoExpediente)0);
Expediente exp2 = new Expediente("Es una caratula modificada", 1, (EstadoExpediente)2);
Expediente exp3 = new Expediente("Una tercera carátula", 3, (EstadoExpediente)3);

//RealizarModificacionExpediente(exp2, (Permiso)1, 3);
/*RealizarAltaExpediente(exp1, (Permiso)1);
RealizarAltaExpediente(exp2 , (Permiso)1);
RealizarAltaExpediente(exp3, (Permiso)1);

// - TRAMITES
Tramite tra1 = new Tramite(exp3.IDExpediente, (EtiquetaTramite)1, "Esto es un tramite", 1);
Tramite tra2 = new Tramite(exp3.IDExpediente, (EtiquetaTramite)1, "Esto es un tramite", 1);
RealizarAltaTramite(tra1, exp3, (Permiso)1, 1);
RealizarAltaTramite(tra2, exp3, (Permiso)1, 1);*/
//RealizarBajaTramite(exp1.IDExpediente, (Permiso)1, exp1);
/*Expediente exp4 = RealizarConsultaPorIdExpediente(3);
Console.WriteLine(exp4);
foreach (Tramite tra in exp4.Tramites)
{
    Console.WriteLine(tra);
}
*/

/*foreach(Tramite tra in RealizarConsultaPorEtiqueta((EtiquetaTramite)1))
{
    Console.WriteLine(tra);
}
*/

Tramite traMod = new Tramite(exp1.IDExpediente, (EtiquetaTramite)1, "Esto es un tramite a modificar", 1);
RealizarModificacionTramite(1, traMod, (Permiso)1,exp1);    

// - METODOS
void RealizarAltaExpediente(Expediente exp, Permiso per, int IdUser = 1)
{
    try
    {
        if ((SA.PoseeElPermiso(IdUser, per) && EV.Validar(exp, IdUser)))
        {
            CUExpAlta.Ejecutar(exp, per, IdUser);
        }
    }
    catch
    {
        Console.WriteLine(" * Hubo una excepción");
    }
}

void RealizarBajaExpediente(Expediente exp, Permiso per, int IdUser = 1)
{
    try
    {
        if(SA.PoseeElPermiso(IdUser, per))
        {
            CUExpBaja.Ejecutar(exp, per, IdUser);
        }
        
    }
    catch
    {
        Console.WriteLine(" * Hubo una excepcion");
    }
}
List<Expediente> RealizarConsultaDeTodosExpedientes()
{
    List<Expediente> listaAux = null;
    try
    {
        listaAux = CUConTodos.Ejecutar();
    }
    catch
    {
        Console.WriteLine(" * Hubo una excepcion");
    }
    return listaAux;
}
void RealizarModificacionExpediente(Expediente exp, Permiso per, int idExpediente, int IdUser = 1)
{
    try
    {
        if (SA.PoseeElPermiso(IdUser, per) && EV.Validar(exp,IdUser))
        {
            CUMod.Ejecutar(idExpediente, exp, IdUser, per);
        }
    }
    catch
    {
        Console.WriteLine(" * Hubo una excepcion");
    }
}
void RealizarAltaTramite(Tramite tra, Expediente exp,Permiso per, int IdUser)
{
    try
    {
        if (SA.PoseeElPermiso(IdUser, per) && (TV.Validador(tra, IdUser)))
        {
            CUTraAlta.Ejecutar(tra, per, exp);
        }
            
    }
    catch { Console.WriteLine(" * Hubo una excepcion"); }
 
}
void RealizarBajaTramite(int idTramite, Permiso per, Expediente exp, int IdUser = 1)
{
    try
    {
        if (SA.PoseeElPermiso(IdUser, per))
        {
            CUTraBaja.BajaTramite(idTramite, IdUser, per, exp);
        }
    }
    catch { Console.WriteLine(" * Hubo una excepcion"); }
}
List<Tramite> RealizarConsultaPorEtiqueta(EtiquetaTramite etiqueta)
{
    List<Tramite> listaAux = null;
    try
    {
        listaAux = CUTraConEti.Ejecutar(etiqueta);
    }
    catch
    {
        Console.WriteLine(" * Hubo una excepcion");
    }
    return listaAux;
}
Expediente RealizarConsultaPorIdExpediente(int idExpediente)
{
    Expediente expAux = null;
    try
    {
        expAux = CUTidExp.Ejecutar(idExpediente);
    }
    catch 
    {
        Console.WriteLine(" * Hubo una excepcion");
    }
    return expAux;
}
void RealizarModificacionTramite(int idModificacionActual, Tramite tra,  Permiso per, Expediente exp, int IdUser = 1)
{
    try
    {
        if ((SA.PoseeElPermiso(IdUser, per)) && (TV.Validador(tra, IdUser)))
        {
            CUTraMod.Ejecutar(idModificacionActual, tra, IdUser, per, exp);
        } 
    }
    catch
    {
        Console.WriteLine(" * Hubo una excepcion");
    }
    
}
