// Importamos las librerías necesarias para validaciones y configuraciones en la base de datos
using System.ComponentModel.DataAnnotations; // Permite validar los datos de entrada
using System.ComponentModel.DataAnnotations.Schema; // Permite configurar el mapeo a la base de datos

namespace MiWeb.Models; // Define el espacio de nombres del modelo

// Definimos la clase Usuario, que representa la tabla "usuarios" en la base de datos
public class Usuario
{
    // 🔹 Clave primaria de la tabla usuarios (Primary Key - PK)
    [Key] // Indica que esta propiedad es la clave primaria en la BD
    public int Id_Usuario { get; set; } // Se genera automáticamente

    // 🔹 Campo que define el rol del usuario (Padre, Madre, Otro)
    [Required] // Indica que este campo es obligatorio
    public required string Rol { get; set; } 

    // 🔹 Género del usuario (Masculino, Femenino, Otro)
    [Required]
    public required string Genero { get; set; }

    // 🔹 Nombre del usuario
    [Required]
    public required string Nombre { get; set; }

    // 🔹 Apellidos del usuario
    [Required]
    public required string Apellidos { get; set; }

    // 🔹 Email del usuario (debe tener formato de correo válido)
    [Required, EmailAddress] // `EmailAddress` valida que sea un correo válido
    public required string Email { get; set; }

    // 🔹 Contraseña del usuario (⚠️ En producción, se recomienda hashearla)
    [Required]
    public required string Password { get; set; }
}
