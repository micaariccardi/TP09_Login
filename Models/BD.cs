using System.Data.SqlClient;
using Dapper;
public static class BD
{
    private static string _connectionString = @"Server=localhost; DataBase=TP09_Login; Trusted_Connection=True;";

    public static bool Existe(string username)
    {
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT Username FROM [User] WHERE Username = @username;";
            string user = db.QueryFirstOrDefault<string>(sql, new {username});

            if (user == null)
                return false;
        }
        return true;
    }
   public static bool ContrasenaCorrecta(string contrasenaInput, string username)
   {
        string contrasenaCorrecta;
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT Contraseña FROM [User] WHERE Username = @username;";
            contrasenaCorrecta = db.QueryFirstOrDefault<string>(sql, new {username});
            if (contrasenaCorrecta == contrasenaInput)
                return true;
        }
        return false;
   }

   public static void CrearUser(string username, string contrasena, string nombre, string apellido, string dni)
   {
        User usuario = new User(username, contrasena, nombre, apellido, dni);
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "INSERT INTO [User](Username, Contraseña, Nombre, Apellido, Dni)  VALUES (@username, @contrasena, @nombre, @apellido, @dni)";
            db.Execute(sql, new {username, contrasena, nombre, apellido, dni});
        }
   }

   public static void CambiarContrasena(string username, string contrasenaNueva)
   {
        string sql = "UPDATE [User] SET Contraseña = "+ contrasenaNueva + " WHERE Username = @" + username + ";";
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql);
        }
   }
}