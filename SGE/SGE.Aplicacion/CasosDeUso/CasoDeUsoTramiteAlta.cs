using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Servicios;
using SGE.Aplicacion.Validadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacion.CasosDeUso
{
    public class CasoDeUsoTramiteAlta(ITramiteRepositorio repo, 
        IExpedienteRepositorio expRepo, 
        ServicioActualizacionEstado updater, 
        ITramiteValidador TV,
        IServicioAutorizacion SA)
    {
        public void Ejecutar(Tramite tramite, Expediente expediente, int IdUser)
        {
            if (!SA.PoseeElPermiso(IdUser))
            {
                throw new AutorizacionException($"El usuario {IdUser} no posee permiso para dar de alta un tramite");
            }
            if (!TV.Validador(tramite))
            {
                throw new ValidacionException();
            }
            repo.AltaTramite(tramite);
            expediente.Tramites.Add(tramite);
            updater.ActualizarEstado(expediente);
            expRepo.ModificacionExpediente(expediente.IDExpediente, expediente);
        }
    }
}
