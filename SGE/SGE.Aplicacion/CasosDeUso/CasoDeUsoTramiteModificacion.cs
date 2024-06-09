using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Servicios;
using SGE.Aplicacion.Validadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repo, 
        ServicioActualizacionEstado updater, 
        IExpedienteRepositorio expRepo,
        ITramiteValidador TV,
        IServicioAutorizacion SA)
    {

        public void Ejecutar(int id, Tramite tramite, int idU, Expediente expediente)
        {
            if (!SA.PoseeElPermiso(idU))
            {
                throw new AutorizacionException($"El usuario {idU} no posee el permiso para modificar un tramite");
            }
            if (!TV.Validador(tramite))
            {
                throw new ValidacionException();
            }
            repo.ModificarTramite(id, tramite, idU);
            updater.ActualizarEstado(expediente);
            expRepo.ModificacionExpediente(expediente.IDExpediente, expediente, idU);
        } 
    }
}
