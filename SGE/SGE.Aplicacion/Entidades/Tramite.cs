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
        public int expID { get; set; }
        public EtiquetaTramite EtiquetaTramite { get; set; }
        public string? Contenido { get; set; }
        public DateTime FechaHoraCreacion { get; set; }
        public DateTime FechaHoraMod {  get; set; }
        public int IDUser { get; set; }

        public Tramite()
        {
            FechaHoraCreacion = DateTime.Now;
        }
        public Tramite(int idtramite, int expid, EtiquetaTramite etiqueta, string? content, int iduser)
        {
            IDTramite = idtramite;
            expID = expid;
            EtiquetaTramite = etiqueta;
            Contenido = content;
            IDUser = iduser;
            FechaHoraCreacion = DateTime.Now;
            FechaHoraMod = DateTime.Now;
        }

        public override string ToString()
        {
            string info = $"ID Tramite: {IDTramite} \nID Expediente: {expID} \nEtiqueta: {EtiquetaTramite} \nContenido: {Contenido} \nFecha creacion: {FechaHoraCreacion} \nFecha modificacion: {FechaHoraMod}\n";
            return info;
        }
    }
}
