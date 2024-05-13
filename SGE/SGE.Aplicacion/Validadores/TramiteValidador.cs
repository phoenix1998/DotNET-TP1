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
        public bool Validador (Tramite tra, int idUserActual)
        {
            try
            {
                if ((idUserActual <= 0) || (tra.Contenido?.Length == 0))
                {
                    throw new ValidacionException();
                }
                return true;
            }
            catch
            {
                return false;
            }
            
        }
    }
}
