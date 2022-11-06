using MensajesAPI.Models;
using MensajesAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
                    ModelState.AddModelError("", "El usuario o la contraseña son incorrectos");
                    return BadRequest(ModelState);
                }
                else
                {
                    //Crear las credenciales
                    return Ok();
                }
            }
            else if (alumno != null)
            {
                if (alumno.Contraseña != usuario.Contraseña)
                {
                    ModelState.AddModelError("", "El usuario o la contraseña son incorrectos");
                    return BadRequest(ModelState);
                }
                else
                {
                    //Crear las credenciales
                    return Ok();
                }
            }
            else
            {
                ModelState.AddModelError("", "Este correo no está asociado a ningun usuario en el sistema");
                return BadRequest(ModelState);
            }
        }
    }
}
