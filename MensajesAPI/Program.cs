using MensajesAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
string llave = builder.Configuration["JwtAuth:Key"];
string issuer = builder.Configuration["JwtAuth:Issuer"];
string audience = builder.Configuration["JwtAuth:Audience"];
string _MyCors = "MyCors";

builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: _MyCors, builder =>
    {
        builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost").AllowAnyHeader().AllowAnyMethod();
    });
});
builder.Services.AddDbContext<itesrcne_pwa_mensajes_181g0231_bdContext>(optionsBuilder => optionsBuilder.UseMySql("server=204.93.216.11;user=itesrcne_luis;password=bgCS4XWebZkBwSE;database=itesrcne_pwa_mensajes_181g0231_bd", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.3.29-mariadb")));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = issuer,
                        ValidAudience = audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(llave)),
                        ValidateIssuerSigningKey = true
                    };
                }
                );
var app = builder.Build();
app.UseCors(_MyCors);
app.UseFileServer();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints=> endpoints.MapDefaultControllerRoute());
app.Run();

