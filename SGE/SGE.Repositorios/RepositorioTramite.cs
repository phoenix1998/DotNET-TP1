
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

namespace SGE.Repositorios;

    public class RepositorioTramite() : ITramiteRepositorio
    {
        static readonly string s_nombreArch = "Tramite.txt";
        static readonly string s_indexArch = "TramiteID.txt";
        static int s_idTra;
    static RepositorioTramite()
    {
        // Si existe el archivo
        if (File.Exists(s_indexArch))
        {
            var lines = File.ReadAllLines(s_indexArch);
            s_idTra = int.Parse(lines[0]);
        }
        else // Si no lo crea y lo setea en 1
        {
            using var sw = new StreamWriter(s_indexArch, true);
            s_idTra = 1;
            sw.WriteLine(s_idTra);
        }
        if (!File.Exists(s_nombreArch))
        {
            using var sw = new StreamWriter(s_nombreArch, true);
            
        }
    }
    public void AltaTramite(Tramite tra, Permiso permisoUser)
    {
        using var sw = new StreamWriter(s_nombreArch, true);

        sw.WriteLine(s_idTra);
        tra.IDTramite = s_idTra;
        s_idTra++;
        sw.WriteLine(tra.expID);
        sw.WriteLine(tra.EtiquetaTramite);
        sw.WriteLine(tra.Contenido);
        sw.WriteLine(DateTime.Now);
        sw.WriteLine(DateTime.Now);
        sw.WriteLine(tra.IDUser);
        sw.WriteLine("-----------");
        using var sw1 = new StreamWriter(s_indexArch, false);
        sw1.WriteLine(s_idTra);
        Console.WriteLine($" - Se ha dado de alta el trámite {tra.IDTramite}");
    }

    public void BajaTramite(int ID, int IDUser, Permiso permisoUser)
    {

        bool ok = false;
        var lines = File.ReadAllLines(s_nombreArch);
        using var sw = new StreamWriter(s_nombreArch, false);

        for (int i = 0; i < lines.Length; i += 8)
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
                sw.WriteLine(lines[i + 7]);

            }
            else
            {
                ok = true;
            }
        }
        if (ok)
        {
            Console.WriteLine(" - Se dio de baja el trámite " + ID);
        }
        else
        {
            throw new RepositorioException();

        }

    }


    public void ModificarTramite(int ID, Tramite tramite, int IDUser, Permiso permisoUser)
    {
        
                var lines = File.ReadAllLines(s_nombreArch);
                using var sw = new StreamWriter(s_nombreArch, false);

                for (int i = 0; i < lines.Length; i += 8)
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
                        sw.WriteLine(lines[i + 7]);
                    }
                    else
                    {
                        sw.WriteLine(tramite.IDTramite);
                        sw.WriteLine(tramite.expID);
                        sw.WriteLine(tramite.EtiquetaTramite);
                        sw.WriteLine(tramite.Contenido);
                        sw.WriteLine(tramite.FechaHoraCreacion);
                        sw.WriteLine(DateTime.Now);
                        sw.WriteLine(tramite.IDUser);
                        Console.WriteLine($" - El trámite {ID} fue modificado");
                    }
                }
    }
        
    
    public List<Tramite> ConsultaPorEtiqueta(EtiquetaTramite etiqueta)
    {
        var lines = File.ReadAllLines(s_nombreArch);
        List<Tramite> listaAux = new List<Tramite>();
        int i = 0;
        
            while (i < lines.Length)
            {
                if (lines[i + 2] == etiqueta.ToString())
                {
                    Tramite aux = new Tramite();
                    aux.IDTramite = int.Parse(lines[i]);
                    aux.expID = int.Parse(lines[i + 1]);
                    aux.EtiquetaTramite = etiqueta;
                    aux.Contenido = lines[i + 3];
                    aux.FechaHoraCreacion = DateTime.Parse(lines[i + 4]);
                    aux.FechaHoraMod = DateTime.Parse(lines[i + 5]);
                    aux.IDUser = int.Parse(lines[i + 6]);
                    listaAux.Add(aux);
                }
                i += 8;
            }
            if(listaAux.Count() < 1)
            {
                throw new RepositorioException();
            }
            
        
        return listaAux;
    }
    public List<Tramite> ConsultaPorIDexpediente(int id)
    {

        var lines = File.ReadAllLines(s_nombreArch);
        List<Tramite> listaAux = new List<Tramite>();
        int eID;
        for (int i = 0; i < lines.Length; i += 8)
        {
            eID = int.Parse(lines[i + 1]);


            if (eID == id)
            {
                Tramite aux = new Tramite();
                aux.IDTramite = int.Parse(lines[i]);
                aux.expID = eID;
                EtiquetaTramite etiqueta;
                if (Enum.TryParse(lines[i + 2], out etiqueta))
                {
                    aux.EtiquetaTramite = etiqueta;
                }
                else
                {
                    Console.WriteLine(" - La etiqueta es inválido");
                }
                aux.Contenido = lines[i + 3];
                aux.FechaHoraCreacion = DateTime.Parse(lines[i + 4]);
                aux.FechaHoraMod = DateTime.Parse(lines[i + 5]);
                aux.IDUser = int.Parse(lines[i + 6]);
                listaAux.Add(aux);

            }
        }
        if(listaAux.Count == 0)
        {
            Console.WriteLine($" - No se encontró ningún trámite con id de expediente {id}");
        }
        return listaAux;
    }

}


