using SGE.Aplicacion.Enumerativos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.Entidades
{
    public class Tramite
    {
        public int IDTramite { get; set; }
        public int expID {get;}
        public EtiquetaTramite EtiquetaTramite { get; set; }
        public string? Contenido { get; set; }
        public DateTime FechaHoraCrecion { get; set; }
        public DateTime FechaHoraMod {  get; set; }
        public int IDUser { get; set; }

        public Tramite()
        {
        }
    }
}
