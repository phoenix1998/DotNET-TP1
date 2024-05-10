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
    public class CasoDeUsoTramiteBaja(ITramiteRepositorio repo, ServicioActualizacionEstado updater, IExpedienteRepositorio expRepo, IServicioAutorizacion SA)
    {
        bool ok = false; // si no lo encuentra
        public void BajaTramite(int id, int idU, Permiso permiso, Expediente expediente)
        {
            try
            {
                if (SA.PoseeElPermiso(idU, permiso))
                {
                    Tramite aux = new Tramite();
                    foreach (Tramite tra in expediente.Tramites)
                    {
                        Console.WriteLine("Entro al foreach");

                        if (tra.IDTramite == id)
                        {
                            aux = tra;
                            Console.WriteLine("Entro al if");

                            ok = true;

                        }

                    }
                    if (!ok)
                    {
                        throw new RepositorioException();
                    }
                    else
                    {
                        repo.BajaTramite(id, idU, permiso);
                        expediente.Tramites.Remove(aux);
                        updater.ActualizarEstado(expediente);
                        expRepo.ModificacionExpediente(expediente.IDExpediente, expediente, 1, (Permiso)1);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Hubo una excepcion");
            }
        }
    }
}
