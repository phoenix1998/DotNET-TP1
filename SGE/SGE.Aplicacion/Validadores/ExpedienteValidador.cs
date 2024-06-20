
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.Validadores
{
    public class ExpedienteValidador : IExpedienteValidador
    {
        public bool Validar(Expediente exp)
        {
            if (string.IsNullOrEmpty(exp.Caratula))
            {
                throw new ValidacionException("La caratula no puede estar vacia");
            }
            return true;
        }
    }
}
