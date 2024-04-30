
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
        /*public bool PoseeElPermiso(int idUser, Permiso permiso)
        {
            if ((idUser > 0) && ((int)permiso == idUser))
            {
                return true;
            }
            else return false;
        }*/
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
                    sw.WriteLine(DateTime.Now.Date);
                    sw.WriteLine(DateTime.Now.Date);
                    sw.WriteLine(tra.IDUser);

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
                    using var sw = new StreamWriter(_nombreArch, true);
                    var lines = File.ReadAllLines(_nombreArch);

                    int i = 0;
                    //int eID = exp.IDExpediente;
                    while ((i < lines.Length) && (int.Parse(lines[i]) != ID))
                    {
                        i += 7;

                    }

                    if (int.Parse(lines[i]) == ID)
                    {
                        sw.WriteLine(lines[i]);
                        sw.WriteLine(lines[i + 1]);
                        sw.WriteLine(lines[i + 2]);
                        sw.WriteLine(lines[i + 3]);
                        sw.WriteLine(lines[i + 4]);
                        sw.WriteLine(lines[i + 5]);
                        sw.WriteLine(lines[i + 6]);
                    Console.WriteLine("El tramite fue eliminado");
                    }
                    else
                    {
                        Console.WriteLine("No se encontro el tramite");
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
                using var sw = new StreamWriter(_nombreArch, true);
                var lines = File.ReadAllLines(_nombreArch);

                int i = 0;
                //int eID = exp.IDExpediente;
                while ((i < lines.Length) && (int.Parse(lines[i]) != ID))
                {
                    i += 7;

                }

                if (int.Parse(lines[i]) == ID)
                {
                    sw.WriteLine(tramite.IDTramite);
                    sw.WriteLine(tramite.expID);
                    sw.WriteLine(tramite.EtiquetaTramite);
                    sw.WriteLine(tramite.Contenido);
                    sw.WriteLine(tramite.FechaHoraCreacion);
                    sw.WriteLine(DateTime.Now.Date);
                    sw.WriteLine(tramite.IDUser);
                    Console.WriteLine("El tramite fue modificado");
                }
                else
                {
                    Console.WriteLine("No se encontro el tramite");
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
                if ((EtiquetaTramite)int.Parse(lines[i + 2]) == etiqueta)
                {
                    Tramite aux = new Tramite();
                    aux.IDTramite = int.Parse(lines[i]);
                    aux.expID = int.Parse(lines[i + 1]);
                    aux.EtiquetaTramite = etiqueta;
                    aux.Contenido = lines[i + 3];
                    aux.FechaHoraCreacion = DateTime.Parse(lines[i + 4]);
                    aux.FechaHoraMod = DateTime.Parse(lines[i + 5]);
                    aux.IDUser = int.Parse(lines[i + 4]);
                    listaAux.Add(aux);
                }
                i += 7;
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

