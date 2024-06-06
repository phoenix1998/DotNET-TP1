using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.Excepciones
{
    public class AutorizacionException : Exception
    {
        public AutorizacionException() { }  
        
        public AutorizacionException(string mensaje) : base(mensaje)
        {
            
        }
    }
}
