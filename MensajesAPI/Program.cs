using MensajesAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
string llave = builder.Configuration["JwtAuth:Key"];
string issuer = builder.Configuration["JwtAuth:Issuer"];
string audience = builder.Configuration["JwtAuth:Audience"];


builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddDbContext<Proyecto_mensajes_pwa_bdContext>(optionsBuilder => optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=Proyecto_mensajes_pwa_bd", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.26-mysql")));
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
app.UseFileServer();
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(endpoints=> endpoints.MapDefaultControllerRoute());
app.Run();

