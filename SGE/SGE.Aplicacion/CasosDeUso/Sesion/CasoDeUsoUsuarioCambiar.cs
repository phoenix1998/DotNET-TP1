using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.CasosDeUso.Sesion;

public class CasoDeUsoUsuarioCambiar(ISesion sesion)
{
    public void Ejecutar(Usuario nuevoUsuario)
    {
        sesion.AlternarSesion();
        sesion.CambiarUsuario(nuevoUsuario);
    }
}