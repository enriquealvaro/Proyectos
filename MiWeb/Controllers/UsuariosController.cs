// Importamos las librerías necesarias para ASP.NET Core y Entity Framework
using Microsoft.AspNetCore.Mvc; // Proporciona funcionalidades para controladores y API REST
using Microsoft.EntityFrameworkCore; // Permite interactuar con la base de datos usando Entity Framework Core
using System.Threading.Tasks; // Permite operaciones asíncronas
using MiWeb.Models; // Importamos los modelos de la aplicación
using MiWeb.Data; // Importamos el contexto de la base de datos
using System.ComponentModel.DataAnnotations; // Permite validaciones en los modelos de datos

// Definimos el controlador de la API para gestionar los usuarios
[ApiController]
[Route("api/usuarios")] // Ruta base de la API: http://localhost:5156/api/usuarios
public class UsuariosController : ControllerBase
{
    private readonly AppDbContext _context; // Contexto de base de datos para interactuar con MySQL

    // Constructor: Recibe el contexto de la base de datos para operar con ella
    public UsuariosController(AppDbContext context)
    {
        _context = context;
    }

    // Método para verificar si la API está en funcionamiento
    [HttpGet]
    public IActionResult Test()
    {
        return Ok(new { mensaje = "API funcionando correctamente" });
    }

    // Método para registrar un nuevo usuario en la base de datos
    [HttpPost("registro")] // Ruta: http://localhost:5156/api/usuarios/registro
    public async Task<IActionResult> RegistrarUsuario([FromBody] Usuario usuario)
    {
        // Verificamos si el email ya está registrado
        if (await _context.Usuarios.AnyAsync(u => u.Email == usuario.Email))
        {
            return BadRequest(new { mensaje = "El email ya está registrado." }); // Retorna error 400 si el email ya existe
        }

        // Guardamos el nuevo usuario en la base de datos
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync(); // Guardamos los cambios de manera asíncrona

        return Ok(new { mensaje = "Usuario registrado con éxito." }); // Retorna mensaje de éxito 200 OK
    }

    // Clase auxiliar para manejar la estructura del JSON en el login
    public class LoginRequest
    {
        public string? Email { get; set; } // Campo para el email (opcional con `?`)
        public string? Password { get; set; } // Campo para la contraseña (opcional con `?`)
    }

    // Método para iniciar sesión
    [HttpPost("login")] // Ruta: http://localhost:5156/api/usuarios/login
    public async Task<IActionResult> IniciarSesion([FromBody] LoginRequest loginRequest)
    {
        // Validamos que los datos sean correctos
        if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Email) || string.IsNullOrEmpty(loginRequest.Password))
        {
            return BadRequest(new { mensaje = "Debe proporcionar un email y una contraseña válidos." }); // Retorna error 400 si faltan datos
        }

        // Buscamos al usuario en la base de datos por su email
        var usuarioExistente = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == loginRequest.Email);

        // Si el usuario no existe, retorna un error 401 (No autorizado)
        if (usuarioExistente == null)
        {
            return Unauthorized(new { mensaje = "El usuario no existe." });
        }

        // Verificamos la contraseña (⚠️ En producción se debe usar hashing en lugar de texto plano)
        if (usuarioExistente.Password != loginRequest.Password)
        {
            return Unauthorized(new { mensaje = "Contraseña incorrecta." }); // Retorna error 401 si la contraseña es incorrecta
        }

        // Si el login es correcto, retornamos los datos del usuario
        return Ok(new { mensaje = "Inicio de sesión exitoso.", usuario = usuarioExistente });
    }
}
