using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.CasosDeUso.Expedientes
{
    public class CasoDeUsoExpedienteConsultaTodos(IExpedienteRepositorio repo)
    {
        public List<Expediente> Ejecutar()
        {
            return repo.ConsultarTodos();
        }
    }
}
