using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.CasosDeUso.Sesion;

public class CasoDeUsoSesionEstado(ISesion sesion)
{
    public bool Ejecutar()
    {
        return sesion.EstaAutorizada();
    }
}