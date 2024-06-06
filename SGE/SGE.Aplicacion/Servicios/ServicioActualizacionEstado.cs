using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.Servicios
{
    public class ServicioActualizacionEstado(EspecificacionCambioEstado especificacionCambioEstado)
    {
        public void ActualizarEstado(Expediente exp)
        {
            
            if (exp.Tramites.Count == 0)
            {
                exp.Estado = EstadoExpediente.RecienIniciado;
            }
            else
            {
                especificacionCambioEstado.DefinirEstado(exp);
            }
            
        }

    }
}
