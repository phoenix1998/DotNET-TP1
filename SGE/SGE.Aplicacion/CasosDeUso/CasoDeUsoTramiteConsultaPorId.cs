using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoTramiteConsultaPorId(ITramiteRepositorio traRepo)
{
    public Tramite Ejecutar(int ID, int expId)
    {
        return traRepo.ConsultaPorId(ID, expId);
    }
}