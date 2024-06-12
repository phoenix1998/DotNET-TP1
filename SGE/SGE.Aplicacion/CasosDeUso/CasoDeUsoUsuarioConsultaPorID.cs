using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoUsuarioConsultaPorID(IUsuarioRepositorio Iusu)
{
    public Usuario Ejecutar(int id)
    {
        // to do: verificar el permiso
        return Iusu.ConsultaPorId(id);
    }
}