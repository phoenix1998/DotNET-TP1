using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.Validadores
{
    public class TramiteValidador : ITramiteValidador
    {
        public bool Validador (Tramite tra)
        {
            if (tra.Contenido == null || tra.Contenido == "")
            {
                throw new ValidacionException("El tramite no puede estar vacio");
            }
            return true;

        }
    }
}
