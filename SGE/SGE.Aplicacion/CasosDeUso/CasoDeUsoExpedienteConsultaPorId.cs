using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoExpedienteConsultaPorId(IExpedienteRepositorio repo) 
    {
        public Expediente Ejecutar(int ID)
        {
           return repo.ConsultaPorID(ID);
        }
    }
}
