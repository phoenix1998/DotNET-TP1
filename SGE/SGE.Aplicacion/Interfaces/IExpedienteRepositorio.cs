using SGE.Aplicacion.Entidades;
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
        public void BajaExpediente(int ID, int IDUser);
        public Expediente ConsultaPorID(int id);
        public List<Expediente> ConsultarTodos();
        public void ModificacionExpediente(int ID, Expediente expediente, int IDUser);
    }
}
