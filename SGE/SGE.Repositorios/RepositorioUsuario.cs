using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Excepciones;
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
    
    public bool TienePermiso(Usuario usuario, Permiso permiso)
    {
        return usuario.Permisos.Contains(permiso);
    }
    public Usuario ConsultaPorId(int id)
    {
        if (Contexto.Usuarios.Find(id) == null)
        {
            throw new RepositorioException($"El usuario con id {id} no existe");
        }
        return Contexto.Usuarios.Find(id);
    }
}