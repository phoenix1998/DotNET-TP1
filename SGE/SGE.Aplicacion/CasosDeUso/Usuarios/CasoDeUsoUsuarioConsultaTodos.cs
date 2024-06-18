using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.CasosDeUso.Usuarios;

public class CasoDeUsoUsuarioConsultaTodos(IUsuarioRepositorio UsuRepo)
{
    public List<Usuario> Ejecutar()
    {
        return UsuRepo.ConsultaTodos();
    }
}