using SGE.Aplicacion.Entidades;

namespace SGE.Aplicacion.Interfaces;

public interface ISesion
{
    void AgregarUsuario(Usuario usuario);
    public bool EstaAutorizada();
    public Usuario? ObtenerUsuario();
    public void AlternarSesion();
    public void CambiarUsuario(Usuario usuario);
}