using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoUsuarioAlta(IUsuarioRepositorio Iusu)
{
    public void Ejecutar(Usuario user)
    {
        // to do: verificar el permiso
        Iusu.AltaUsuario(user);
    }
}
