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
    public class ServicioActualizacionEstado
    {
        public void ActualizarEstado(Expediente exp)
        {
            if (exp.Tramites.Count == 0)
            {
                exp.Estado = (EstadoExpediente)0;
            }
            else
            {

                if (exp.Tramites.Last().EtiquetaTramite.Equals((EtiquetaTramite)3))
                    {
                       exp.Estado = (EstadoExpediente)2;
                    }
                    if (exp.Tramites.Last().EtiquetaTramite.Equals((EtiquetaTramite)1))
                    {
                        exp.Estado = (EstadoExpediente)1;
                    }
                    if (exp.Tramites.Last().EtiquetaTramite.Equals((EtiquetaTramite)5))
                    {
                        exp.Estado = (EstadoExpediente)4;
                    }
            }
        }
        
    }
}
