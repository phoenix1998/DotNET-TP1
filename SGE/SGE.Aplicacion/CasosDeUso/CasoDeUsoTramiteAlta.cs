using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoTramiteAlta(ITramiteRepositorio repo)
    {
        public void Ejercutar(Tramite tramite,int id)
        {
            repo.AltaTramite(tramite,id);
        }
    }
}
