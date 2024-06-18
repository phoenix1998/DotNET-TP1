using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.CasosDeUso.Sesion;

public class CasoDeUsoSesionAlternar(ISesion sesion)
{
    public void Ejecutar()
    {
        sesion.AlternarSesion();
    }
}