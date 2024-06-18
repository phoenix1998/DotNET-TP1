using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.CasosDeUso.Sesion;

public class CasoDeUsoUsuarioObtener(ISesion sesion)
{
    public Usuario? Ejecutar()
    {
        return sesion.ObtenerUsuario();
    }
}