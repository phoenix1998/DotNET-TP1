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
    public class CasoDeUsoExpedienteModificacion(IExpedienteRepositorio repo)
    {
        public void Ejecutar(int id, Expediente exp, int IDUser, Permiso permisoUser)
        {
            repo.ModificacionExpediente(id, exp, IDUser, permisoUser);
        }
    }
}
