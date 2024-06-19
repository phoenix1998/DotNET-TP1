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
        if (usuario.Id == 1)
        {
            usuario.Permisos.Add(Permiso.ExpedienteAlta);
            usuario.Permisos.Add(Permiso.ExpedienteBaja);
            usuario.Permisos.Add(Permiso.ExpedienteModificacion);
            usuario.Permisos.Add(Permiso.TramiteAlta);
            usuario.Permisos.Add(Permiso.TramiteBaja);
            usuario.Permisos.Add(Permiso.TramiteModificacion);
            Contexto.SaveChanges();
        }
        
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
    public void Modificar(Usuario usuario, bool opcion)
    {
        /*Usuario? usu;
        usu = Contexto.Usuarios.Find(usuario);
        if (usu == null)
        {
            throw new RepositorioException("No se encontro el usuario");
        }
        usu = usuario;*/
        if (!opcion)
        {
            usuario.Contraseña = hasher.ObtenerHash(usuario.Contraseña);
        }
        Contexto.Usuarios.Update(usuario);
        Contexto.SaveChanges();
    }
    public void BajaUsuario(int id)
    {
        Usuario? usuario = Contexto.Usuarios.Find(id);
        if (usuario == null)
        {
            throw new RepositorioException($"El usuario con id {id} no existe");
        }
        Contexto.Usuarios.Remove(usuario);
        Contexto.SaveChanges();
    }
}