namespace SGE.Repositorios;

using Microsoft.EntityFrameworkCore;

public class GestorSQLite
{
    public static void Inicializar()
    {
        //NOTA: Es conveniente establecer la propiedad journal mode de la base de datos sqlite en DELETE.
        using var context = new SgeContext();
        context.Database.EnsureCreated();
        var connection = context.Database.GetDbConnection();
        connection.Open();
        using (var command = connection.CreateCommand())
        {
            command.CommandText = "PRAGMA journal_mode=DELETE;";
            command.ExecuteNonQuery();
        }
    }
}