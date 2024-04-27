using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.Servicios
{
    public class ServicioActualizacionProvisorio: IServicioAutorizacion
    {
        public bool PoseeElPermiso(int IDUser, Permiso permiso)
        {
            if (IDUser == 1)
            {
                return true;
            }
            else return false;
        }
    }
    
}
