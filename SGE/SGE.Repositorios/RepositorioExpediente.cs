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

public class RepositorioExpediente() : IExpedienteRepositorio
{
    readonly string _nombreArch = "Expediente.txt";
    static readonly string s_indexArch = "ExpedienteID.txt";
    static int s_idExp;
    /*public bool PoseeElPermiso(int idUser, Permiso permiso)
    {
        if ((idUser > 0) && ((int)permiso == idUser))
        {
            return true;
        }
        else return false;
    }*/
    // IServicioAutorizacion SA;
    static RepositorioExpediente()
    {
        // Si existe el archivo
        if(File.Exists(s_indexArch))
        {
            var lines = File.ReadAllLines(s_indexArch);
            s_idExp = int.Parse(lines[0]);
        }
        else // Si no lo crea y lo setea en 1
        {
            using var sw = new StreamWriter(s_indexArch, true);
            s_idExp = 1;
            sw.WriteLine(s_idExp);
        }
    }
    public void AltaExpediente(Expediente exp, int idUser)
    {
        
        using var sw = new StreamWriter(_nombreArch, true);
        sw.WriteLine(s_idExp);
        exp.IDExpediente = s_idExp;
        s_idExp++;
        sw.WriteLine(exp.Caratula);
        exp.FechaHoraCreacion = DateTime.Now;
        sw.WriteLine(DateTime.Now);
        exp.FechaHoraModificacion = DateTime.Now;
        sw.WriteLine(DateTime.Now);
        sw.WriteLine(exp.IDUser);
        sw.WriteLine(exp.Estado);
        sw.WriteLine("-----------");
        using var sw1 = new StreamWriter(s_indexArch, false);
        sw1.WriteLine(s_idExp);
    }
    public void BajaExpediente(Expediente exp, int idUser)
    {

        bool ok = false;
        var lines = File.ReadAllLines(_nombreArch);
        using var sw = new StreamWriter(_nombreArch, false);

        for (int i = 0; i < lines.Length; i += 7)
        {
            if ((int.Parse(lines[i]) != exp.IDExpediente))
            {
                sw.WriteLine(lines[i]);
                sw.WriteLine(lines[i + 1]);
                sw.WriteLine(lines[i + 2]);
                sw.WriteLine(lines[i + 3]);
                sw.WriteLine(lines[i + 4]);
                sw.WriteLine(lines[i + 5]);
                sw.WriteLine(lines[i + 6]);
                
            }
            else
            {
                ok = true;
                //Console.WriteLine("Se dio de baja el expediente " + exp.IDExpediente);
            }
        }
        if (!ok)
        {
            throw new RepositorioException($"No existe el expediente {exp.IDExpediente}");
        }
        
    }



    public void ModificacionExpediente(int ID, Expediente exp, int idUser)
    {

        var lines = File.ReadAllLines(_nombreArch);
        using var sw = new StreamWriter(_nombreArch, false);
        bool ok = false;
        for (int i = 0; i < lines.Length; i += 7)
        {
            if (int.Parse(lines[i]) != ID)
            {
                sw.WriteLine(lines[i]);
                sw.WriteLine(lines[i + 1]);
                sw.WriteLine(lines[i + 2]);
                sw.WriteLine(lines[i + 3]);
                sw.WriteLine(lines[i + 4]);
                sw.WriteLine(lines[i + 5]);
                sw.WriteLine(lines[i + 6]);
            }
            else
            {

                sw.WriteLine(lines[i]);
                sw.WriteLine(exp.Caratula);
                sw.WriteLine(lines[i+2]);
                sw.WriteLine(DateTime.Now);
                sw.WriteLine(exp.IDUser);
                sw.WriteLine(exp.Estado);
                sw.WriteLine(lines[i + 6]);
                ok = true;
            }
        }
        if (ok)
        {
            Console.WriteLine($"El expediente {ID} fue modificado (para ver nosotros)");
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
                    throw new RepositorioException("El estado del expediente es invalido");
                }
                
            }

            else
            {
                i += 7;
            }

        }
        throw new RepositorioException();
        // Si no se encontró ningún expediente con el ID especificado, tiramos una excepcion
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
                        throw new RepositorioException("El estado del expediente es invalido");
                    }
                    listaAux.Add(aux);
                }
                i += 7;
            }
     
        return listaAux;
    }
}

