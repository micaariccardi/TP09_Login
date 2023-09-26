public class User
{
    public string username {get; set;}
    public string contrasena {get; set;}
    public string nombre {get; set;}
    public string apellido {get; set;}
    public string dni {get; set;}

    public User(string name, string contra, string nom, string ape, string DNI)
    {
        username = name;
        contrasena = contra;
        nombre = nom;
        apellido = ape;
        dni = DNI;
    }

    public User(){}
}