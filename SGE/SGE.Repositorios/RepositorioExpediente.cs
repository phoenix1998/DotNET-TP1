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
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;

public class RepositorioExpediente(IServicioAutorizacion SA, ExpedienteValidador EV) : IExpedienteRepositorio
{
    readonly string _nombreArch = "Expediente.txt";
    int idExp = 1;
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


        using var sw = new StreamWriter(_nombreArch, true);
        sw.WriteLine(exp.IDExpediente);
        sw.WriteLine(exp.Caratula);
        sw.WriteLine(DateTime.Now);
        sw.WriteLine(DateTime.Now);
        sw.WriteLine(exp.IDUser);
        sw.WriteLine(exp.Estado);


    }
    public void BajaExpediente(Expediente exp, Permiso permisoUser, int idUser)
    {


        bool ok = false;
        var lines = File.ReadAllLines(_nombreArch);
        using var sw = new StreamWriter(_nombreArch, false);

        for (int i = 0; i < lines.Length; i += 6)
        {
            if ((int.Parse(lines[i]) != exp.IDExpediente))
            {
                sw.WriteLine(lines[i]);
                sw.WriteLine(lines[i + 1]);
                sw.WriteLine(lines[i + 2]);
                sw.WriteLine(lines[i + 3]);
                sw.WriteLine(lines[i + 4]);
                sw.WriteLine(lines[i + 5]);
                Console.WriteLine("Se dio de baja el expediente " + exp.IDExpediente);
            }
            else
            {
                ok = true;
            }
        }
        if (!ok)
        {
            throw new RepositorioException();
        }

    }



    public void ModificacionExpediente(int ID, Expediente exp, int idUser, Permiso permisoUser)
    {

        var lines = File.ReadAllLines(_nombreArch);
        using var sw = new StreamWriter(_nombreArch, false);

        for (int i = 0; i < lines.Length; i += 6)
        {
            if (int.Parse(lines[i]) != ID)
            {
                sw.WriteLine(lines[i]);
                sw.WriteLine(lines[i + 1]);
                sw.WriteLine(lines[i + 2]);
                sw.WriteLine(lines[i + 3]);
                sw.WriteLine(lines[i + 4]);
                sw.WriteLine(lines[i + 5]);
            }
            else
            {
                sw.WriteLine(exp.IDExpediente);
                sw.WriteLine(exp.Caratula);
                sw.WriteLine(exp.FechaHoraCreacion);
                sw.WriteLine(DateTime.Now);
                sw.WriteLine(exp.IDUser);
                sw.WriteLine(exp.Estado);
                Console.WriteLine("El Expediente fue modificado");
            }
        }
    }

    public Expediente ConsultaPorID(int id)
    {
        using var sr = new StreamReader(_nombreArch);
        var lines = File.ReadAllLines(_nombreArch);
        
            int eID;
            int i = 0;
            while (i < lines.Length)
            {
                eID = int.Parse(lines[i]);

                if (eID == id)
                {
                    EstadoExpediente estado;

                    if (Enum.TryParse(lines[i + 5], out estado))
                    {
                        return new Expediente
                        {
                            IDExpediente = eID,
                            Caratula = (lines[i + 1]),
                            FechaHoraCreacion = DateTime.Parse(lines[i + 2]),
                            FechaHoraModificacion = DateTime.Parse(lines[i + 3]),
                            IDUser = int.Parse(lines[i + 4]),
                            Estado = estado,
                        };
                    }
                    else
                    {
                        Console.WriteLine("El estado es invalido");
                    }

                }

                else
                {
                    i += 6;
                }
                
            }
        return null;


        // Si no se encontró ningún expediente con el ID especificado, devolvemos null.

    }

    public List<Expediente> ConsultarTodos()
    {

        //using var sr = new StreamReader (_nombreArch);
        var lines = File.ReadAllLines(_nombreArch);
        List<Expediente> listaAux = null;
        int i = 0;
        
            while (i < lines.Length)
            {
                if (lines[i] != "")
                {
                    if (listaAux == null)
                    {
                        listaAux = new List<Expediente>();
                    }
                    Expediente aux = new Expediente();
                    aux.IDExpediente = int.Parse(lines[i]);
                    aux.Caratula = lines[i + 1];
                    aux.FechaHoraCreacion = DateTime.Parse(lines[i + 2]);
                    aux.FechaHoraModificacion = DateTime.Now;
                    aux.IDUser = int.Parse(lines[i + 4]);
                    //Console.WriteLine(lines[i + 5].ToString());
                    EstadoExpediente estado;
                    if (Enum.TryParse(lines[i + 5], out estado))
                    {
                        aux.Estado = estado;
                    }
                    else
                    {
                        Console.WriteLine("El estado es invalido");
                    }
                    listaAux.Add(aux);
                }
                i += 6;
            }
            
        
        
        return listaAux;
    }
}

