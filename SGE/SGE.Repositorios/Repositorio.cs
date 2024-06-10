namespace SGE.Repositorios;

    public abstract class Repositorio
    {
        protected readonly SgeContext Contexto; //   - GRACIAS FABRO

        protected Repositorio(SgeContext contexto)
        {
            Contexto = contexto; // Pasarle el contexto 
            GestorSQLite.Inicializar(); //  Ya que estamos, asegurarnos de que existe la base de datos
        }
    }
