using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.Interfaces
{
    public interface IExpedienteRepositorio
    {
        public void AltaExpediente(Expediente expediente);
        public void BajaExpediente(Expediente expediente);
        public Expediente ConsultaPorId(int id);
        public List<Expediente> ConsultarTodos();
        public void ModificacionExpediente(int ID, Expediente expediente);
    }
}
