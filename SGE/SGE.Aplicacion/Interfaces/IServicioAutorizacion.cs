using SGE.Aplicacion.Enumerativos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.Interfaces
{
    public interface IServicioAutorizacion
    {
        public bool PoseeElPermiso(int IDUser, Permiso permiso);
        
    }
}
