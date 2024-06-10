using SGE.Aplicacion.Enumerativos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGE.Aplicacion.Entidades;

namespace SGE.Aplicacion.Interfaces
{
    public interface IServicioAutorizacion
    {
        public bool PoseeElPermiso(Usuario usuario,Permiso permiso);
        
    }
}
