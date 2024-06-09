using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoTramiteBaja(ITramiteRepositorio repo, 
        ServicioActualizacionEstado updater, 
        IExpedienteRepositorio expRepo,
        IServicioAutorizacion SA)
    {
        bool ok = false; // si no lo encuentra
        public void BajaTramite(int id, int idU, Expediente expediente)
        {
            if (!SA.PoseeElPermiso(idU))
            {
                throw new AutorizacionException($"El usuario {idU} no posee el permiso para dar de baja un tramite");
            }
            Tramite aux = new Tramite();
            foreach (Tramite tra in expediente.Tramites)
            {
                if (tra.IDTramite == id)
                {
                    aux = tra;
                    ok = true;
                }

            }
            if (ok)
            {
                repo.BajaTramite(id, idU);
                expediente.Tramites.Remove(aux);
                updater.ActualizarEstado(expediente);
                expRepo.ModificacionExpediente(expediente.IDExpediente, expediente, idU);
            }
            

        }
    }
}