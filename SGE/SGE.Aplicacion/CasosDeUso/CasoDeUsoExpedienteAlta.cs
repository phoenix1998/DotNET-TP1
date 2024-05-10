using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Validadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio repo, IServicioAutorizacion SA, ExpedienteValidador EV)
    {
        public void Ejecutar(Expediente exp, Permiso permisoUser, int idUser)
        {
            try
            {
                if (SA.PoseeElPermiso(idUser, permisoUser) && (EV.Validar(exp)))
                {
                    repo.AltaExpediente(exp, permisoUser, idUser);
                }
            }
            catch
            {
                Console.WriteLine("Hubo una exepción");
            }
                
        }
    }
}
