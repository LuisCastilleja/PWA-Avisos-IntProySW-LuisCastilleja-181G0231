using MensajesAPI.Models;
using MensajesAPI.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MensajesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public Proyecto_mensajes_pwa_bdContext Context { get;}
        public IConfiguration Configuration { get; }

        public LoginController(Proyecto_mensajes_pwa_bdContext context, IConfiguration configuration)
        {
            Context = context;
            Configuration = configuration;
        }
        [HttpPost]
        public IActionResult Post([FromBody] ModeloUsuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Correo))
            {
                ModelState.AddModelError("", "Proporcione su correo para iniciar sesión");
                return BadRequest(ModelState);
            }
            if (string.IsNullOrWhiteSpace(usuario.Contraseña))
            {
                ModelState.AddModelError("", "Proporcione su contraseña para iniciar sesión");
                return BadRequest(ModelState);
            }
            var profesor = Context.Docente.FirstOrDefault(x => x.Correo == usuario.Correo);
            var alumno = Context.Alumno.FirstOrDefault(x => x.Correo == usuario.Correo);

            if (profesor!=null)
            {
                if (profesor.Contraseña != usuario.Contraseña)
                {
                    ModelState.AddModelError("", "El correo o la contraseña son incorrectos");
                    return BadRequest(ModelState);
                }
                else
                {
                    //Crear la identidad del usuario.
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, $"{profesor.NombreCompleto}"));
                    claims.Add(new Claim(ClaimTypes.Role, "Profesor"));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, $"{profesor.Id}"));
                    //Crear un token.
                    var handler = new JwtSecurityTokenHandler();
                    var descriptor = new SecurityTokenDescriptor();

                    descriptor.Issuer = Configuration["JwtAuth:Issuer"];
                    descriptor.Audience = Configuration["JwtAuth:Audience"];
                    //La identidad a quien se emite el token.
                    descriptor.Subject = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                    //En cuanto tiempo se expira el token que mandamos
                    descriptor.Expires = DateTime.UtcNow.AddDays(10);
                    descriptor.IssuedAt = DateTime.UtcNow;
                    descriptor.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtAuth:Key"])), SecurityAlgorithms.HmacSha256);

                    //Creamos el token
                    var token = handler.CreateToken(descriptor);
                    //Serializamos el token
                    var tokenSerializado = handler.WriteToken(token);

                    //Regresamos el token
                    return Ok(tokenSerializado);
                }
            }
            else if (alumno != null)
            {
                if (alumno.Contraseña != usuario.Contraseña)
                {
                    ModelState.AddModelError("", "El correo o la contraseña son incorrectos");
                    return BadRequest(ModelState);
                }
                else
                {
                    //Crear la identidad del usuario.
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, $"{alumno.NombreCompleto}"));
                    claims.Add(new Claim(ClaimTypes.Role, "Alumno"));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, $"{alumno.Id}"));
                    //Crear un token.
                    var handler = new JwtSecurityTokenHandler();
                    var descriptor = new SecurityTokenDescriptor();

                    descriptor.Issuer = Configuration["JwtAuth:Issuer"];
                    descriptor.Audience = Configuration["JwtAuth:Audience"];
                    //La identidad a quien se emite el token.
                    descriptor.Subject = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                    //En cuanto tiempo se expira el token que mandamos
                    descriptor.Expires = DateTime.UtcNow.AddDays(10);
                    descriptor.IssuedAt = DateTime.UtcNow;
                    descriptor.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtAuth:Key"])), SecurityAlgorithms.HmacSha256);

                    //Creamos el token
                    var token = handler.CreateToken(descriptor);
                    //Serializamos el token
                    var tokenSerializado = handler.WriteToken(token);

                    //Regresamos el token
                    return Ok(tokenSerializado);
                }
            }
            else
            {
                ModelState.AddModelError("", "El correo o la contraseña son incorrectos");
                return BadRequest(ModelState);
            }
        }
    }
}
