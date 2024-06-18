using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.CasosDeUso.Tramites
{
    public class CasoDeUsoTramiteConsultaPorEtiqueta(ITramiteRepositorio repo)
    {
        public List<Tramite> Ejecutar(EtiquetaTramite etiqueta)
        {
            return repo.ConsultaPorEtiqueta(etiqueta);
        }
    }
}
