
using SGE.Aplicacion.Interfaces;
namespace SGE.Aplicacion.CasosDeUso.Hash;
public class CasoDeUsoObtenerHash(IHasher Hasher)
{
    public string Obtener(string contraseña)
    {
        return Hasher.ObtenerHash(contraseña);
    }
}