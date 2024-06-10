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
    public class CasoDeUsoExpedienteModificacion(IExpedienteRepositorio repo,
        IServicioAutorizacion SA,
        IExpedienteValidador EV)
    {
        public void Ejecutar(int idExp, Expediente exp, Usuario usu)
        {
            if (!SA.PoseeElPermiso(usu, Permiso.ExpedienteModificacion))
            {
                throw new AutorizacionException($"El usuario {usu.Id} no posee el permiso para modificar un expediente");
            }


            if (!EV.Validar(exp))
            {
                throw new ValidacionException();
            }
            repo.ModificacionExpediente(idExp, exp);
        }
    }
}
