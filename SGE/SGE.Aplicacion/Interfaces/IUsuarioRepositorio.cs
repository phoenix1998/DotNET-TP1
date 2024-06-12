using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;

namespace SGE.Aplicacion.Interfaces;

public interface IUsuarioRepositorio
{
    public void AltaUsuario(Usuario user);
    public bool TienePermiso(Usuario user, Permiso permiso);
    public Usuario ConsultaPorId(int id);
}