using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repo) 
    {
        public void Ejecutar(int id, int idU)
        {
            repo.BajaExpediente(id, idU);
        }
    }
}
