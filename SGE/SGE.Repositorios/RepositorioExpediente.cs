namespace SGE.Repositorios;
using SGE.Aplicacion;
using SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Servicios;
using SGE.Aplicacion.Validadores;
using System.IO;
using System.Security.Cryptography;

public class RepositorioExpediente(IServicioAutorizacion SA, ExpedienteValidador EV) : IExpedienteRepositorio
{
    readonly string _nombreArch = "Expediente.txt";
    /*public bool PoseeElPermiso(int idUser, Permiso permiso)
    {
        if ((idUser > 0) && ((int)permiso == idUser))
        {
            return true;
        }
        else return false;
    }*/
   // IServicioAutorizacion SA;
    public void AltaExpediente(Expediente exp, Permiso permisoUser, int idUser)
    {
        try
        {
            if (SA.PoseeElPermiso(idUser, permisoUser) && (EV.Validar(exp)))
            {
                using var sw = new StreamWriter(_nombreArch, true);
                sw.WriteLine(exp.IDExpediente);
                sw.WriteLine(exp.Caratula);
                sw.WriteLine(DateTime.Now.Date);
                sw.WriteLine(DateTime.Now.Date);
                sw.WriteLine(exp.IDUser);
                sw.WriteLine(exp.Estado);
            }
        }
        catch
        {
            Console.WriteLine("Hubo una excepcion");
        }

    }
    public void BajaExpediente(Expediente exp, Permiso permisoUser, int idUser)
    {
         
        //var lines = File.ReadAllLines(_nombreArch);
        //using var sw = new StreamWriter(_nombreArch, true);
        

        try
        {
            if (SA.PoseeElPermiso(idUser, permisoUser))
            {
                using var sr = new StreamReader(_nombreArch, true);
                string str = sr.ReadToEnd();
                File.Delete(_nombreArch);
                using (StreamWriter swriter = new StreamWriter(_nombreArch, false))
                {
                   
                    swriter.Write(str);
                }

                //int i = lines.Length-6;
                /*while((i >= lines.Length) && (int.Parse(lines[i]) != exp.IDExpediente)){
                    i -= 6;
                    
                }
                
                if (int.Parse(lines[i]) == exp.IDExpediente)
                {
                    Console.WriteLine("Entre al if");
                    sw.WriteLine();
                    sw.WriteLine();
                    sw.WriteLine();
                    sw.WriteLine();
                    sw.WriteLine();
                    sw.WriteLine();
                    //sw.WriteLine("final")
                    Console.WriteLine("El Expediente fue eliminado");
                }
                else
                {
                    Console.WriteLine("No se encontro el expediente");
                }*/
            }
        }
        catch(Exception e)
        {
            //throw new AutorizacionException();
            Console.WriteLine(e.Message);
        }
        
    }
    public void ModificacionExpediente(int ID,Expediente exp, int idUser, Permiso permisoUser )
    {
        try
        {
            if (SA.PoseeElPermiso(idUser, permisoUser) && (EV.Validar(exp)))
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
                    sw.WriteLine(DateTime.Now.Date);
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
            Console.WriteLine("Hubo una excepcion");
        }
    }
    public Expediente ConsultaPorID(int id)
    {
        using var sr = new StreamReader(_nombreArch);
        var lines = File.ReadAllLines(_nombreArch);
        try
        {
            int eID;
            int i = 0;
            while (i < lines.Length)
            {
                eID = int.Parse(lines[i]);

                if (eID == id)
                {
                    return new Expediente
                    {
                        IDExpediente = eID,
                        Caratula = (lines[i + 1]),
                        FechaHoraCreacion = DateTime.Parse(lines[i+2]),
                        FechaHoraModificacion = DateTime.Parse(lines[i+3]),
                        IDUser = int.Parse(lines[i+4]),
                        Estado = (EstadoExpediente)int.Parse(lines[i+5])
                    };
                }
                else
                {
                    i += 6;
                }
            }
            return null;
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
                i += 6;
            }
            return listaAux;
        }
        catch
        {
            Console.WriteLine("Hubo una excepcion");
            return listaAux;
        }
    }
}

