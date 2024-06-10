using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Validadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoExpedienteAlta(
        IExpedienteRepositorio repo, 
        IExpedienteValidador EV,
        IServicioAutorizacion SA
        )

    {
        public void Ejecutar(Expediente exp, Usuario usu)
        {
            if (!SA.PoseeElPermiso(usu, Permiso.ExpedienteAlta))
            {
                throw new AutorizacionException($"El usuario {usu.Id} no posee el permiso para dar de alta un expediente");
            }
                
                
            if (!EV.Validar(exp))
            {
                throw new ValidacionException();
            }
            repo.AltaExpediente(exp);
        }
            
    }
}
