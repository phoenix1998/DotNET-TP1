using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Servicios;

namespace SGE.Aplicacion.CasosDeUso.Tramites
{
    public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repo, 
        ServicioActualizacionEstado updater, 
        IExpedienteRepositorio expRepo,
        ITramiteValidador TV,
        IServicioAutorizacion SA)
    {

        public void Ejecutar(int Tramiteid, Tramite tramite, Usuario usu, Expediente expediente)
        {
            if (!SA.PoseeElPermiso(usu, Permiso.TramiteModificacion))
            {
                throw new AutorizacionException($"El usuario {usu.Id} no posee el permiso para modificar un tramite");
            }
            if (!TV.Validador(tramite))
            {
                throw new ValidacionException();
            }
            repo.ModificarTramite(Tramiteid, tramite);
            updater.ActualizarEstado(expediente);
            
        } 
    }
}
