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
        public int Id { get; set; }
        public EtiquetaTramite EtiquetaTramite { get; set; }
        public string? Contenido { get; set; }
        public DateTime FechaHoraCreacion { get; set; }
        public DateTime FechaHoraMod {  get; set; }
        public int ExpedienteId { get; set; }

        public override string ToString()
        {
            string info = $"ID Tramite: {Id} \nEtiqueta: {EtiquetaTramite} \nContenido: {Contenido} \nFecha creacion: {FechaHoraCreacion} \nFecha modificacion: {FechaHoraMod}\n";
            return info;
        }
    }
}
