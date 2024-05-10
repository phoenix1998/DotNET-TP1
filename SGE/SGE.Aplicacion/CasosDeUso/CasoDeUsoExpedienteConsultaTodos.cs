using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Validadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoExpedienteConsultaTodos(IExpedienteRepositorio repo, IServicioAutorizacion SA, ExpedienteValidador EV)
    {
        public List<Expediente> Ejecutar()
        {
            
                return repo.ConsultarTodos();
            
            
        }
    }
}
