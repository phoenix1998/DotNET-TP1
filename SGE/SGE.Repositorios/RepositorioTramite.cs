
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

    public class RepositorioTramite(IServicioAutorizacion SA, TramiteValidador TV) : ITramiteRepositorio
    {
        readonly string _nombreArch = "Tramite.txt";
        
        public void AltaTramite(Tramite tra, int IDUser, Permiso permisoUser)
        {
            try
            {
                if (SA.PoseeElPermiso(IDUser, permisoUser) && (TV.Validador(tra)))
                {
                    using var sw = new StreamWriter(_nombreArch, true);
                    sw.WriteLine(tra.IDTramite);
                    sw.WriteLine(tra.expID);
                    sw.WriteLine(tra.EtiquetaTramite);
                    sw.WriteLine(tra.Contenido);
                    sw.WriteLine(DateTime.Now);
                    sw.WriteLine(DateTime.Now);
                    sw.WriteLine(tra.IDUser);
                    sw.WriteLine("-----------");

                }
            }
            catch
            {
                throw new AutorizacionException();
            }
        }
        public void BajaTramite(int ID, int IDUser, Permiso permisoUser)
        {
        try
        {
            if (SA.PoseeElPermiso(IDUser, permisoUser))
            {
                bool ok = false;
                var lines = File.ReadAllLines(_nombreArch);
                using var sw = new StreamWriter(_nombreArch, false);

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
                        ok = true;
                    }
                }
                if (!ok)
                {
                    Console.WriteLine("Se dio de baja el tramite " + ID);
                }
                else
                {
                    Console.WriteLine($"El tramite {ID} no se encontro");

                }
            }
        }
        catch
        {
            throw new AutorizacionException();
        }
    }
    public void ModificarTramite(int ID, Tramite tramite, int IDUser, Permiso permisoUser)
    {
        try
        {
            if (SA.PoseeElPermiso(IDUser, permisoUser) && (TV.Validador(tramite)))
            {
                var lines = File.ReadAllLines(_nombreArch);
                using var sw = new StreamWriter(_nombreArch, false);

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
                        Console.WriteLine($"El tramite {ID} fue modificado");
                    }
                }
            }
        }
        catch
        {
            Console.WriteLine("Hubo una excepcion");
        }
    }
    public List<Tramite> ConsultaPorEtiqueta(EtiquetaTramite etiqueta)
    {
        var lines = File.ReadAllLines(_nombreArch);
        List<Tramite> listaAux = new List<Tramite>();
        int i = 0;
        try
        {
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
            return listaAux;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return listaAux;
        }
    }
    public List<Tramite> ConsultaPorIDexpediente(int id)
    {
        
        var lines = File.ReadAllLines(_nombreArch);
        List<Tramite> listaAux = new List<Tramite>();
        try
        {
            int eID;
            for (int i = 0;i < lines.Length; i+=8)
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
                        Console.WriteLine("La etiqueta es invalido");
                    }
                    aux.Contenido = lines[i + 3];
                    aux.FechaHoraCreacion = DateTime.Parse(lines[i + 4]);
                    aux.FechaHoraMod = DateTime.Parse(lines[i + 5]);
                    aux.IDUser = int.Parse(lines[i + 6]);
                    listaAux.Add(aux);
                }
            }
            return listaAux;
        }
        catch
        {
            throw new AutorizacionException();
            //return null;
        }
        
        
    }
}

