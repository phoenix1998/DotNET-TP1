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
        public void Ejecutar(int id, Expediente exp, int IDUser)
        {
            if (!SA.PoseeElPermiso(IDUser))
            {
                throw new AutorizacionException($"El usuario {IDUser} no posee el permiso para modificar un expediente");
            }


            if (!EV.Validar(exp))
            {
                throw new ValidacionException();
            }
            repo.ModificacionExpediente(id, exp, IDUser);
        }
    }
}
