namespace SGE.Repositorios;
using SGE.Aplicacion;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

public class RepositorioExpediente : IExpedienteRepositorio
{
    readonly string _nombreArch = "Expediente.txt";
    
    public void AltaExpediente(Expediente exp)
    {
        using var se = new StreamWriter(_nombreArch, true);
    }
}

