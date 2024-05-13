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
    public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio repo)
    {
        public void Ejecutar(Expediente exp, Permiso permisoUser, int idUser)
        {
            repo.AltaExpediente(exp, permisoUser, idUser);           
        }
    }
}
