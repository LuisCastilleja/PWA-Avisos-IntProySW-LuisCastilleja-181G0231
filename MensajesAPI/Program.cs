using MensajesAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Proyecto_mensajes_pwa_bdContext>(optionsBuilder => optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=Proyecto_mensajes_pwa_bd", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.26-mysql")));
var app = builder.Build();
app.UseFileServer();
app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(endpoints=> endpoints.MapRazorPages());
app.Run();

