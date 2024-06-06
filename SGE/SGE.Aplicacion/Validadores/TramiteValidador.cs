using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Excepciones;
namespace SGE.Aplicacion.Validadores
{
    public class TramiteValidador
    {
        public bool Validador (Tramite tra)
        {
            if (tra.Contenido?.Length == 0)
            {
                throw new ValidacionException("El tramite no puede estar vacio");
            }
            return true;

        }
    }
}
