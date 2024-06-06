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
            if (exp.Caratula?.Length == 0)
            {
                throw new ValidacionException("La caratula no puede estar vacia");
            }
            return true;
        }
    }
}
