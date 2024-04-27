using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Excepciones;
namespace SGE.Aplicacion.Validadores
{
    public class ExpedienteValidador
    {
        public bool Validar(Expediente exp)
        {
            try
            {
                if ((exp.IDUser <= 0) || (exp.Caratula?.Length == 0))
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
