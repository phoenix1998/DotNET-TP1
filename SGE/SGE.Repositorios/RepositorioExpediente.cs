using Microsoft.EntityFrameworkCore;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;

namespace SGE.Repositorios;

public class RepositorioExpediente : Repositorio ,IExpedienteRepositorio
{
    public RepositorioExpediente(SgeContext contexto) : base(contexto) {}
    
    public void AltaExpediente(Expediente expediente)
    {
        Contexto.Expedientes.Add(expediente);
        Contexto.SaveChanges();
    }
    
    public void BajaExpediente(Expediente exp)
    {
        Expediente? expedienteConsultado = Contexto.Expedientes.Where(e => e.Id == exp.Id).SingleOrDefault();
        if (expedienteConsultado == null)
        {
            throw new RepositorioException($"No se encontro el expediente {exp.Id}");
        }
        Contexto.Expedientes.Remove(expedienteConsultado);
        Contexto.SaveChanges();
    }
    
    public void ModificacionExpediente(int Id, Expediente expediente)
    {
        Expediente? expedienteConsulta = Contexto.Expedientes.Where(e => e.Id == Id).SingleOrDefault();
        if (expedienteConsulta == null)
        {
            throw new RepositorioException($"No se encontro el expediente {Id}");
        }
        expedienteConsulta = expediente;
        Contexto.SaveChanges();
    }
    
    public List<Expediente> ConsultarTodos()
    {
        List<Expediente> listaExpedientes = Contexto.Expedientes.ToList();
        return listaExpedientes;
    }
    public Expediente ConsultaPorId(int id)
    {
        Expediente? expedienteConsultado = Contexto.Expedientes.Where(e => e.Id == id)
            .Include(e => e.Tramites).SingleOrDefault();
        if (expedienteConsultado == null)
        {
            throw new RepositorioException($"No se encontro el expediente {id}");
        }
        return expedienteConsultado;
    }
}

