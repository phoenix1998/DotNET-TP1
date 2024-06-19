using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;

namespace SGE.Aplicacion.Interfaces;

public interface IUsuarioRepositorio
{
    public void AltaUsuario(Usuario user);
    public bool TienePermiso(Usuario user, Permiso permiso);
    public Usuario ConsultaPorId(int id);
    public List<Usuario> ConsultaTodos();
    public void Modificar(Usuario user, bool opcion);
    public void BajaUsuario(int id);
}