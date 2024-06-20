using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.Validadores;

public class UsuarioValidador : IUsuarioValidador
{
    public bool Validar(Usuario usuario)
    {
        if (usuario.Id < 1)
        {
            throw new ValidacionException($"El usuario {usuario.Nombre} no tiene un id valido");
        }

        return true;
    }
}