using System.Diagnostics;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Servicios;

namespace SGE.Aplicacion.CasosDeUso.Tramites
{
    public class CasoDeUsoTramiteAlta(ITramiteRepositorio repo, 
        IExpedienteRepositorio expRepo, 
        ServicioActualizacionEstado updater, 
        ITramiteValidador TV,
        IServicioAutorizacion SA)
    {
        public void Ejecutar(Tramite tramite, Expediente expediente, Usuario usu)
        {
            if (!SA.PoseeElPermiso(usu, Permiso.TramiteAlta))
            {
                throw new AutorizacionException($"El usuario {usu.Id} no posee permiso para dar de alta un tramite");
            }
            if (!TV.Validador(tramite))
            {
                throw new ValidacionException();
            }
            
            expediente.Tramites.Add(tramite);
            updater.ActualizarEstado(expediente);
            repo.AltaTramite(tramite);
            expRepo.ModificacionExpediente(expediente.Id, expediente);
        }
    }
}
