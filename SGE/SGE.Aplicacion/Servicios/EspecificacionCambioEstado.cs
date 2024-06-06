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
    public class EspecificacionCambioEstado()
    {
        public void DefinirEstado(Expediente exp)
        {
                if (exp.Tramites.Last().EtiquetaTramite.Equals(EtiquetaTramite.Resolucion))
                {
                    exp.Estado = EstadoExpediente.ConResolucion;
                }
                if (exp.Tramites.Last().EtiquetaTramite.Equals(EtiquetaTramite.PaseAEstudio))
                {
                    exp.Estado = EstadoExpediente.ParaResolver;
                }
                if (exp.Tramites.Last().EtiquetaTramite.Equals(EtiquetaTramite.PaseAlArchivo))
                {
                    exp.Estado = EstadoExpediente.Finalizado;
                }
           
            }
        }
    }
        

