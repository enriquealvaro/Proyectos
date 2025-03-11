// Definimos el espacio de nombres del contexto de datos
namespace MiWeb.Data;

// Importamos las librerías necesarias para trabajar con Entity Framework Core
using Microsoft.EntityFrameworkCore; // Permite interactuar con la base de datos
using MiWeb.Models; // Importamos los modelos de la aplicación

// Definimos el contexto de base de datos (DbContext), que permite interactuar con MySQL
public class AppDbContext : DbContext
{
    // 🔹 Constructor que recibe las opciones de configuración del DbContext
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // 🔹 Definimos la tabla "Usuarios" en la base de datos
    public DbSet<Usuario> Usuarios { get; set; }
}
