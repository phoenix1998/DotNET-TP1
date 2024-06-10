using SGE.Aplicacion.Entidades;

namespace SGE.Aplicacion.Interfaces;

public interface IUsuarioValidador
{
    public bool Validar(Usuario usuario);
}