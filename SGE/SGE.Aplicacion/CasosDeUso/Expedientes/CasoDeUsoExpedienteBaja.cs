using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.CasosDeUso.Expedientes
{
    public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repo, IServicioAutorizacion SA)
    {

        public void Ejecutar(Expediente exp,Usuario usu)
        {
            if (!SA.PoseeElPermiso(usu, Permiso.ExpedienteBaja))
            {
                throw new AutorizacionException($"El usuario {usu.Id} no tiene permisos para dar de baja un expediente.");
            }
            repo.BajaExpediente(exp);
        }
    }
}
