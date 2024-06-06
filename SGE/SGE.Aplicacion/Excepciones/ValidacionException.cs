using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.Excepciones
{
    public class ValidacionException : Exception
    {
        public ValidacionException() { }    
        public ValidacionException(string mensaje) : base(mensaje) 
        {
            
        }
    }
}
