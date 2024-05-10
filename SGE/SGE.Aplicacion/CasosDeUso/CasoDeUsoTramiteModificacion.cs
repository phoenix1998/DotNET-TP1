using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
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
    public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repo, ServicioActualizacionEstado updater, IExpedienteRepositorio expRepo, IServicioAutorizacion SA, TramiteValidador TV)
    {

        public void Ejecutar(int id, Tramite tramite, int idU, Permiso permiso, Expediente expediente)
        {
            try
            {
                if (SA.PoseeElPermiso(idU, permiso) && (TV.Validador(tramite)))
                {
                    repo.ModificarTramite(id, tramite, idU, permiso);
                    updater.ActualizarEstado(expediente);
                    expRepo.ModificacionExpediente(expediente.IDExpediente, expediente, 1, (Permiso)1);
                }

            }
            catch
            {
                Console.WriteLine("Hubo una exepcion");
            }
        }
       
    }
}
