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
    public class CasoDeUsoTramiteAlta(ITramiteRepositorio repo, IExpedienteRepositorio expRepo, ServicioActualizacionEstado updater, IServicioAutorizacion SA, TramiteValidador TV)
    {
        public void Ejecutar(Tramite tramite,int id,Permiso permiso, Expediente expediente)
        {
            try
            {
                if (SA.PoseeElPermiso(id, permiso) && (TV.Validador(tramite)))
                {
                    repo.AltaTramite(tramite, id, permiso);
                    expediente.Tramites.Add(tramite);
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
