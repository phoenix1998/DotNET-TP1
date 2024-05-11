using SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Servicios;
using SGE.Aplicacion.Validadores;
using SGE.Repositorios;

namespace SGE.Aplicacion;
public class Program
{
    public static void Main(string[] args)
    {
        
        bool showMenu = true;
        while (showMenu)
        {
            showMenu = MainMenu();
        }
    }
    
    private static bool MainMenu()
    {
        // Config de dependencias
        IServicioAutorizacion SA = new ServicioAutorizacionProvisorio();
        ExpedienteValidador EV = new ExpedienteValidador();
        TramiteValidador TV = new TramiteValidador();
        IExpedienteRepositorio expRepo = new RepositorioExpediente(SA, EV);
        ITramiteRepositorio traRepo = new RepositorioTramite(SA, TV);
        ServicioActualizacionEstado updater = new ServicioActualizacionEstado();

        //Casos de usos
        CasoDeUsoExpedienteAlta CUExpAlta = new CasoDeUsoExpedienteAlta(expRepo, SA, EV);
        CasoDeUsoExpedienteBaja CUExpBaja = new CasoDeUsoExpedienteBaja(expRepo, traRepo, SA);
        CasoDeUsoExpedienteConsultaTodos CUConTodos = new CasoDeUsoExpedienteConsultaTodos(expRepo, SA, EV);
        CasoDeUsoExpedienteModificacion CUMod = new CasoDeUsoExpedienteModificacion(expRepo, SA, EV);
        CasoDeUsoTramiteAlta CUTraAlta = new CasoDeUsoTramiteAlta(traRepo, expRepo, updater, SA, TV);
        CasoDeUsoTramiteBaja CUTraBaja = new CasoDeUsoTramiteBaja(traRepo, updater, expRepo, SA);
        CasoDeUsoTramiteConsultaPorEtiqueta CUTraConEti = new CasoDeUsoTramiteConsultaPorEtiqueta(traRepo);
        CasoDeUsoTramiteConsultaPorIdExpediente idExp = new CasoDeUsoTramiteConsultaPorIdExpediente(traRepo, expRepo);
        CasoDeUsoTramiteModificacion CUTraMod = new CasoDeUsoTramiteModificacion(traRepo, updater, expRepo, SA, TV);
        Console.Clear();
        Console.WriteLine("Elige una opcion");
        Console.WriteLine("1: Dar de alta un expediente");
        Console.WriteLine("2: Dar de baja un expediente");
        Console.WriteLine("3: Consultar todos los expedientes");
        Console.WriteLine("4: Modificar un expediente");
        Console.WriteLine("5: Dar de alta un tramite");
        Console.WriteLine("6: Dar de baja un tramite");
        Console.WriteLine("7: Consultar tramite por etiqueta");
        Console.WriteLine("8: Consultar tramite por ID de expediente");
        Console.WriteLine("9: Modificar un tramite");
        Console.WriteLine("0: Salir");
        switch (Console.ReadLine())
        {
            case "0":
                return false;
            case "1":
                AltaExpediente(SA, EV, expRepo);
                return true;
            case "2":
                BajaExpediente(SA, expRepo);
                return true;
            case "3":
                ConsultarTodosExp(expRepo);
                return true;
            case "4":
                ModificacionExpediente(SA, EV, expRepo);
                return true;
            case "5":
                AltaTramite(SA, TV, traRepo);
                return true;
            case "6":
                BajaTramite(SA, TV, traRepo);
                return true;
            case "7":
                ConsultaTramitePorEtiqueta(traRepo);
                return true;
            case "8":
                ConsulaIDExpediente(traRepo);
                return true;
            case "9":
                ModificacionTramite(SA, TV, traRepo);
                return true;
            default: 
                Console.WriteLine("Opcion incorrecta");
                return true;
        }
    }
    private static void AltaExpediente(IServicioAutorizacion SA, ExpedienteValidador EV, IExpedienteRepositorio expRepo)
    {
        try
        {
            if(SA.PoseeElPermiso)
        }
    }
}


// Programa
Expediente exp1 = new Expediente();
exp1.IDExpediente = 1;
exp1.Caratula = "Es una caratula";
exp1.Estado = (EstadoExpediente)0;
exp1.IDUser = 1;
CUExpAlta.Ejecutar(exp1, (Permiso)1, 1);


Expediente exp2 = new Expediente();
exp2.IDExpediente = 2;
exp2.Caratula = "Es una caratula 2";
exp2.Estado = (EstadoExpediente)2;
exp2.IDUser = 2;
CUExpAlta.Ejecutar(exp2, (Permiso)1, 1);

Expediente exp3 = new Expediente();
exp3.IDExpediente = 3;
exp3.Caratula = "Es una caratula 3";
exp3.Estado = (EstadoExpediente)3;
exp3.IDUser = 3;
CUExpAlta.Ejecutar(exp3, (Permiso)1, 1);

// Tramites
Tramite tra1 = new Tramite();
tra1.IDTramite = 1;
tra1.expID = 1;
tra1.EtiquetaTramite = (EtiquetaTramite)1;
tra1.Contenido = "Esto es un tramite";
tra1.IDUser = 1;

CUTraAlta.Ejecutar(tra1, 1, (Permiso)1, exp1);

Tramite tra2 = new Tramite();
tra2.IDTramite = 2;
tra2.expID = 1;
tra2.EtiquetaTramite = (EtiquetaTramite)2;
tra2.Contenido = "Esto es un tramite 2";
tra2.IDUser = 2;
CUTraAlta.Ejecutar(tra2, 1, (Permiso)1, exp1);

Tramite tra3 = new Tramite();
tra3.IDTramite = 3;
tra3.expID = 1;
tra3.EtiquetaTramite = (EtiquetaTramite)3;
tra3.Contenido = "Esto es un tramite 3";
tra3.IDUser = 3;
CUTraAlta.Ejecutar(tra3, 1, (Permiso)1, exp1);


/*Expediente exp4 = idExp.Ejecutar(1);
Console.WriteLine(exp4);
foreach (Tramite tra in exp4.Tramites)
{
    Console.WriteLine(tra);
}
Console.WriteLine("---------------");
CUTraBaja.BajaTramite(2, 1, (Permiso)1, exp4);
Console.WriteLine("---------------");
foreach (Tramite tra in exp4.Tramites)
{
    Console.WriteLine(tra);
}*/


