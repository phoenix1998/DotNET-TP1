using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Validadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repo, ITramiteRepositorio traRepo, IServicioAutorizacion SA)
    {

        public void Ejecutar(Expediente exp,int idUser)
        {
            if (!SA.PoseeElPermiso(idUser))
            {
                throw new AutorizacionException($"El usuario {idUser} no tiene permisos para dar de baja un expediente.");
            }
            if (exp.Tramites != null)
            {
                foreach (Tramite tra in exp.Tramites)
                {
                    traRepo.BajaTramite(tra.IDTramite, idUser);
                }
            }
            repo.BajaExpediente(exp, idUser);
        }
    }
}
