using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.Servicios
{
    public class ServicioAutorizacionProvisorio: IServicioAutorizacion
    {

        public bool PoseeElPermiso(int IDUser, Permiso permiso)
        {
            try
            {
                if (IDUser != 1)
                {
                    throw new AutorizacionException();
                }
                return true;
            }
            catch
            {
                return false;
            }
            
        }
    }
    
}
