using SGE.Aplicacion.Enumerativos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.Entidades
{
    public class Expediente
    {
        public int IDExpediente { get; set; }
        public string? Caratula { get; set; }
        public DateTime? FechaHoraCreacion { get; set; }
        public DateTime? FechaHoraModificacion { get; set; }
        public int IDUser { get; set; }
        public EstadoExpediente Estado { get; set; } /* 1: Recién iniciado,  2: Para resolver, 3: con resolucion, 4: en notificacion, 5: finalizado */
        public List<Tramite> Tramites { get; set; } = new List<Tramite>();

        public override string ToString()
        {
            string info = $"ID Expediente: {IDExpediente} \nCaratula: {Caratula}\nFecha creacion: {FechaHoraCreacion} \nFecha modificacion: {FechaHoraModificacion}\nID de usuario: {IDUser} \nEstado del expediente: {Estado}\n";
            return info;
        }
    }
}
