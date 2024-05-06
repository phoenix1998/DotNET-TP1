using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoTramiteConsultaPorIdExpediente(ITramiteRepositorio repo) 
    {
        public List<Tramite> Ejecutar(int ID)
        {
           //Expediente exp = repo.ConsultaPorID(ID);
            return repo.ConsultaPorIDexpediente(ID);
        }
    }
}
