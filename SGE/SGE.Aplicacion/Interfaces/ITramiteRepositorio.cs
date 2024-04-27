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
        public void AltaTramite(Tramite tramite,int IDUser);
        public void BajaTramite(int ID, int IDUser);
        public void ModificarTramite(int ID, Tramite tramite, int IDUser);
        public List<Tramite> ConsultaPorEtiqueta(EtiquetaTramite etiqueta);
    }
}
