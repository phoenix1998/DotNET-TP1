using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.Interfaces
{
    public interface ITramiteRepositorio
    {
        public void AltaTramite(Tramite tramite);
        public void BajaTramite(int ID);
        public void ModificarTramite(int ID, Tramite tramite);
        public List<Tramite> ConsultaPorEtiqueta(EtiquetaTramite etiqueta);
        public Tramite ConsultaPorId(int ID, int expId);
        
    }
}
