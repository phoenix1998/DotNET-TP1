namespace SGE.Repositorios;
using SGE.Aplicacion;
using SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Validadores;
using System.Security.Cryptography;

public class RepositorioExpediente : IExpedienteRepositorio, IServicioAutorizacion
{
    readonly string _nombreArch = "Expediente.txt";
    public bool PoseeElPermiso(int idUser, Permiso permiso)
    {
        if ((idUser > 0) && ((int)permiso == idUser))
        {
            return true;
        }
        else return false;
    }
    public void AltaExpediente(Expediente exp, Permiso permisoUser, int idUser)
    {
        try
        {
            if (PoseeElPermiso(idUser, permisoUser))
            {
                using var sw = new StreamWriter(_nombreArch, true);
                sw.WriteLine(exp.IDExpediente);
                sw.WriteLine(exp.Caratula);
                sw.WriteLine(exp.FechaHoraCreacion);
                sw.WriteLine(exp.FechaHoraModificacion);
                sw.WriteLine(exp.IDUser);
                sw.WriteLine(exp.Estado);
            }
        }
        catch
        {
            throw new AutorizacionException();
        }
    }
    public void BajaExpediente(Expediente exp, Permiso permisoUser, int idUser)
    {
        try
        {
            if (PoseeElPermiso(idUser, permisoUser))
            {
                using var sw = new StreamWriter(_nombreArch, true);
                var lines = File.ReadAllLines(_nombreArch);
            
                int i = 0;
                //int eID = exp.IDExpediente;
                while((i < lines.Length) && (int.Parse(lines[i]) != exp.IDExpediente)){
                    i += 6;
                    
                }
                
                if (int.Parse(lines[i]) == exp.IDExpediente)
                {
                    sw.WriteLine(lines[i]);
                    sw.WriteLine(lines[i + 1]);
                    sw.WriteLine(lines[i + 2]);
                    sw.WriteLine(lines[i + 3]);
                    sw.WriteLine(lines[i + 4]);
                    sw.WriteLine(lines[i + 5]);
                    Console.WriteLine("El Expediente fue eliminado");
                }
                else
                {
                    Console.WriteLine("No se encontro el expediente");
                }
            }
        }
        catch
        {
            throw new AutorizacionException();
        }

    }
    public void ModificacionExpediente(int ID,Expediente exp, int idUser, Permiso permisoUser )
    {
        try
        {
            if (PoseeElPermiso(idUser, permisoUser))
            {
                using var sw = new StreamWriter(_nombreArch, true);
                var lines = File.ReadAllLines(_nombreArch);

                int i = 0;
                //int eID = exp.IDExpediente;
                while ((i < lines.Length) && (int.Parse(lines[i]) != exp.IDExpediente))
                {
                    i += 6;

                }

                if (int.Parse(lines[i]) == ID)
                {
                    sw.WriteLine(exp.IDExpediente);
                    sw.WriteLine(exp.Caratula);
                    sw.WriteLine(exp.FechaHoraCreacion);
                    sw.WriteLine(exp.FechaHoraModificacion);
                    sw.WriteLine(exp.IDUser);
                    sw.WriteLine(exp.Estado);
                    Console.WriteLine("El Expediente fue modificado");
                }
                else
                {
                    Console.WriteLine("No se encontro el expediente");
                }
            }
        }
        catch
        {
            throw new AutorizacionException();
        }
    }
    public Expediente ConsultaPorID(int id)
    {
        using var sr = new StreamReader(_nombreArch);
        try
        {
            while (!sr.EndOfStream)
            {
                int pID = int.Parse(sr.ReadLine());
                string pName = sr.ReadLine();
                double pPrice = double.Parse(sr.ReadLine());

                if (pID == id)
                {
                    return new Expediente
                    {
                        ID = pID,
                        Nombre = pName,
                        Precio = pPrice
                    };
                }
            }
        }
        catch 
        {
            throw new AutorizacionException();
        }
    }
    public List<Expediente> ConsultarTodos()
    {

        //using var sr = new StreamReader (_nombreArch);
        var lines = File.ReadAllLines(_nombreArch);
        List<Expediente> listaAux = new List<Expediente>();
        int i = 0;
        try
        {
            while (i < lines.Length)
            {
                if (lines[i] != "")
                {
                    Expediente aux = new Expediente();
                    aux.IDExpediente = int.Parse(lines[i + 5]);
                    aux.Caratula = lines[i + 1];
                    aux.FechaHoraCreacion = DateTime.Parse(lines[i + 2]);
                    aux.FechaHoraModificacion = DateTime.Parse(lines[i + 3]);
                    aux.IDUser = int.Parse(lines[i + 4]);
                    aux.Estado = (EstadoExpediente) int.Parse(lines[i + 5]);
                    listaAux.Add(aux);
                }
            }
            return listaAux;
        }
        catch
        {
            throw new Exception();
        }
    }
}

