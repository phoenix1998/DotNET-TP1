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
        public void AltaTramite(Tramite tramite, Permiso permisoUser);
        public void BajaTramite(int ID, int IDUser, Permiso permisoUser);
        public void ModificarTramite(int ID, Tramite tramite, int IDUser, Permiso permisoUser);
        public List<Tramite> ConsultaPorEtiqueta(EtiquetaTramite etiqueta);
        public List<Tramite> ConsultaPorIDexpediente(int id);
    }
}
