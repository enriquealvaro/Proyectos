using Microsoft.EntityFrameworkCore;
using MiWeb.Data; // ⚠ Asegúrate de que "MiWeb" es el nombre correcto de tu proyecto

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://localhost:5156"); //  Configura el puerto correcto


builder.Services.AddAuthorization();
builder.Services.AddRazorPages();

// Configurar la conexión a MySQL con Pomelo
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))); // Mejor que usar MySqlServerVersion

builder.Services.AddControllers();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Permite servir archivos HTML/CSS/JS desde wwwroot

app.UseRouting();

app.UseAuthentication(); // Agregar antes de `UseAuthorization`
app.UseAuthorization();

// Redirigir automáticamente a login.html al abrir la web
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/login.html");
        return;
    }
    await next();
});

app.MapControllers(); // Necesario para que funcione la API
app.MapRazorPages();

app.Run();
