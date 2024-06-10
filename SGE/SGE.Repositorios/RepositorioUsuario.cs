using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

namespace SGE.Repositorios;

public class RepositorioUsuario : Repositorio , IUsuarioRepositorio
{
    public RepositorioUsuario(SgeContext contexto) : base(contexto) {}
    
    public void AltaUsuario(Usuario usuario)
    {
        Contexto.Usuarios.Add(usuario);
        Contexto.SaveChanges();
    }
}