using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoTramiteConsultaPorEtiqueta(ITramiteRepositorio repo)
    {
        public List<Tramite> Ejecutar(EtiquetaTramite etiqueta)
        {
            return repo.ConsultaPorEtiqueta(etiqueta);
        }
    }
}
