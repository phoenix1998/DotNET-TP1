using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.Excepciones
{
    public class RepositorioException : Exception
    {
        public RepositorioException() : base() 
        {
            Console.WriteLine("La entidad no fue encontrada");
        }
    }
}
