using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.Excepciones
{
    public class ValidacionException : Exception
    {
        //public string MensajeError = "La entidad no cumple con los requisitos";
        public ValidacionException() : base() 
        {
            Console.WriteLine("La entidad no cunple con los requisitos");
        }
    }
}
