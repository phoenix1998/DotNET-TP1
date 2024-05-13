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
    public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repo, ITramiteRepositorio traRepo)
    {

        public void Ejecutar(Expediente exp, Permiso permisoUser, int idUser)
        {
            if (exp.Tramites != null)
            {
                foreach (Tramite tra in exp.Tramites)
                {
                    traRepo.BajaTramite(tra.IDTramite, idUser, permisoUser);
                }
            }
            repo.BajaExpediente(exp, permisoUser, idUser);
        }
    }
}
