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
    public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repo, IServicioAutorizacion SA)
    {

        public void Ejecutar(Expediente exp,Usuario usu)
        {
            if (!SA.PoseeElPermiso(usu, Permiso.ExpedienteBaja))
            {
                throw new AutorizacionException($"El usuario {usu.Id} no tiene permisos para dar de baja un expediente.");
            }
            repo.BajaExpediente(exp);
        }
    }
}
