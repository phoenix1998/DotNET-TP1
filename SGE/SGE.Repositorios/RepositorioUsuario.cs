using Microsoft.EntityFrameworkCore;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;

using SGE.Aplicacion.Servicios;


namespace SGE.Repositorios;

public class RepositorioUsuario : Repositorio , IUsuarioRepositorio
{
    public IHasher hasher = new Hasher();
    public RepositorioUsuario(SgeContext contexto) : base(contexto) {}
    
    public void AltaUsuario(Usuario usuario)
    {
        if (usuario.Contraseña == null || usuario.Contraseña == "" || usuario.Nombre == null || usuario.Nombre == "")
        {
            throw new RepositorioException("ERROR: El usuario o la contraseña no pueden ser nulos o vacíos");
        }
        
        usuario.Contraseña = hasher.ObtenerHash(usuario.Contraseña);
        
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
    public List<Usuario> ConsultaTodos()
    {
        List<Usuario> consultarTodos = Contexto.Usuarios.ToList() ?? new List<Usuario>();

        //Como es una lista, no pasa nada al devolverla vacía
        return consultarTodos;
    }
}