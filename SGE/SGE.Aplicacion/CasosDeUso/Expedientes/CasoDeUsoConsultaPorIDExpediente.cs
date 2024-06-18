using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.CasosDeUso.Expedientes;

public class CasoDeUsoConsultaPorIdExpediente(IExpedienteRepositorio exprepo)
{
    public Expediente Ejecutar(int ID)
    {
        return exprepo.ConsultaPorId(ID);
        
    }
}