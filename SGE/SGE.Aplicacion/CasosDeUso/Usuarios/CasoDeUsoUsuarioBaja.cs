using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.CasosDeUso.Usuarios;

public class CasoDeUsoUsuarioBaja(IUsuarioRepositorio Iusu)
{
    public void Ejecutar(int Id) => Iusu.BajaUsuario(Id);
}