using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.CasosDeUso.Usuarios;

public class CasoDeUsoUsuarioModificar(IUsuarioRepositorio Iusu)
{
    public void Ejecutar(Usuario usuario, bool opcion = false)
    {
        Iusu.Modificar(usuario, opcion);
    }
}