using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP09_Login.Models;

namespace TP09_Login.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index() // Login!
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

     public IActionResult CrearCuenta()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreandoCuenta(string username, string contrasena, string nombre, string apellido, string dni, string confirmacion)
    {
        if (confirmacion == contrasena)
        {
            BD.CrearUser(username, contrasena,nombre, apellido, dni);
            return View("Index");
        }        
        return View("CrearCuenta");
    }

    [HttpPost]
    public IActionResult Bienvenida(string username, string contrasena)
    {
        if (BD.Existe(username) && BD.ContrasenaCorrecta(contrasena, username))
        {
            return View();
        }
        return View("Index");
    }

    public IActionResult OlvideContrasena()
    {
        return View();
    }

   [HttpPost]
    public IActionResult CambiarContraseña(string username, string contrasenaNueva)
    {
        BD.CambiarContrasena(username, contrasenaNueva);
        return View("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
