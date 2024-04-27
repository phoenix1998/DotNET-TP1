using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repo)
    {
        public void Ejecitar(int id, Tramite tramite, int idU)
        {
            repo.ModificarTramite(id, tramite, idU);
        }
       
    }
}
