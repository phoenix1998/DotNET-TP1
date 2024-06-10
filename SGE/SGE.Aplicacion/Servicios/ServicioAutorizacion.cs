using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGE.Aplicacion.Entidades;

namespace SGE.Aplicacion.Servicios
{
    public class ServicioAutorizacion: IServicioAutorizacion
    {
        public bool PoseeElPermiso(Usuario usuario, Permiso permiso) => 
            (usuario?.Permisos?.FindIndex(p => p == permiso) ?? -1) != -1;
    }
    
}
