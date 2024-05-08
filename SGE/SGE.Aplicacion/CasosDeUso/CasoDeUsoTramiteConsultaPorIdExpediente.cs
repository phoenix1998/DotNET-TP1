using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoTramiteConsultaPorIdExpediente(ITramiteRepositorio repo, IExpedienteRepositorio expRepo) 
    {
        public Expediente Ejecutar(int ID)
        {
            Expediente exp = expRepo.ConsultaPorID(ID);
            exp.Tramites = repo.ConsultaPorIDexpediente(ID);
            return exp;
        }
    }
}
