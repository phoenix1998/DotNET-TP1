using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Servicios;

namespace SGE.Aplicacion.CasosDeUso.Tramites
{
    public class CasoDeUsoTramiteBaja(ITramiteRepositorio repo, 
        ServicioActualizacionEstado updater, 
        IExpedienteRepositorio expRepo,
        IServicioAutorizacion SA)
    {
        
        public void Ejecutar(int idTramite, Usuario usu, Expediente expediente)
        {
            if (!SA.PoseeElPermiso(usu, Permiso.TramiteBaja))
            {
                throw new AutorizacionException($"El usuario {usu.Id} no posee el permiso para dar de baja un tramite");
            }
            repo.BajaTramite(idTramite);
            updater.ActualizarEstado(expediente);
            
        }
    }
}