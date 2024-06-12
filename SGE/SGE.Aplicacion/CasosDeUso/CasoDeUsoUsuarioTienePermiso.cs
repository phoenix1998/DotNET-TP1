using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoUsuarioTienePermiso(IUsuarioRepositorio Iusu)
{
    public bool Ejecutar(Usuario user, Permiso permiso)
    {
        return Iusu.TienePermiso(user, permiso);
    }
}