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
    public class CasoDeUsoTramiteBaja(ITramiteRepositorio repo, ServicioActualizacionEstado updater, IExpedienteRepositorio expRepo)
    {
        bool ok = false; // si no lo encuentra
        public void BajaTramite(int id, int idU, Permiso permiso, Expediente expediente)
        {

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
                repo.BajaTramite(id, idU, permiso);
                expediente.Tramites.Remove(aux);
                updater.ActualizarEstado(expediente);
                expRepo.ModificacionExpediente(expediente.IDExpediente, expediente, 1, (Permiso)1);
            }
            

        }
    }
}