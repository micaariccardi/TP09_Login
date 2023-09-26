using System.Data.SqlClient;
using Dapper;
public class BD
{
    private static string _connectionString = @"Server=localhost; DataBase=Login; Trusted_Connection=True;";

    public bool Existe(string username)
    {
        string user = "";
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT Username FROM User WHERE Username = "+ username + ";";
            user = db.QueryFirstOrDefault<string>(sql);
            if (user == "")
                return false;        
        }
        return true;
    }
   public bool ContrasenaCorrecta(string contrasenaInput, string username)
   {
        string contrasenaCorrecta;
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT contrasena FROM User WHERE Username = " + username + ";";
            contrasenaCorrecta = db.QueryFirstOrDefault<string>(sql);
            if (contrasenaCorrecta == contrasenaInput)
                return true;
        }
        return false;
   }

   public void CrearUser(string username, string contrasena, string nombre, string apellido, string dni)
   {
        User usuario = new User(username, contrasena, nombre, apellido, dni);
   }

   public void CambiarContrasena(string username, string contrasenaNueva)
   {
        string sql = "UPDATE User SET contrasena = "+ contrasenaNueva + " WHERE username = " + username + ";";
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql);
        }
   }
}