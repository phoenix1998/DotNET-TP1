using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;

namespace SGE.Repositorios;

public class RepositorioTramite : Repositorio, ITramiteRepositorio
{
    //Llamar al constructor de la clase base con un contexto
    public RepositorioTramite(SgeContext contexto) : base(contexto) {}

    public void AltaTramite(Tramite tramite)
    {
        Contexto.Tramites.Add(tramite);
        Contexto.SaveChanges();
    }

    public void BajaTramite(int ID)
    {
        Tramite? tramiteCosultado = Contexto.Tramites.Where(t => t.Id == ID).SingleOrDefault();
        if (tramiteCosultado == null)
        {
            throw new RepositorioException($"No se encontro el tramite {ID}");
        }
        Contexto.Tramites.Remove(tramiteCosultado);
        Contexto.SaveChanges();
    }

    public void ModificarTramite(int ID, Tramite tramite)
    {
        Tramite? tramiteConsulta = Contexto.Tramites.Where(t => t.Id == ID).SingleOrDefault();
        if (tramiteConsulta == null)
        {
            throw new RepositorioException($"No se encontro el tramite {ID}");
        }

        tramiteConsulta = tramite;
        Contexto.SaveChanges();
    }

    public List<Tramite> ConsultaPorEtiqueta(EtiquetaTramite etiqueta)
    {
        List<Tramite> listaTramites = Contexto.Tramites.Where(t => t.EtiquetaTramite == etiqueta).ToList();
        return listaTramites;
    }

    public List<Tramite> ConsultaPorIDexpediente(int idExpediente)
    {
        List<Tramite> listaTramites = Contexto.Tramites.Where(t => t.ExpedienteId == idExpediente).ToList();
        return listaTramites;
    }
}