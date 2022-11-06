using MensajesAPI.Models;
using MensajesAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MensajesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        public Proyecto_mensajes_pwa_bdContext Context { get; }
        public IConfiguration Configuration { get; }

        Repository<AlumnoMensaje> repositoryAlumno_Mensaje;
        Repository<Mensaje> repositoryMensajes;

        List<Mensaje> listaMensajes = new List<Mensaje>();

        public AlumnoController(Proyecto_mensajes_pwa_bdContext context, IConfiguration configuration)
        {
            Context = context;
            Configuration = configuration;
            repositoryMensajes = new Repository<Mensaje>(Context);
            repositoryAlumno_Mensaje = new Repository<AlumnoMensaje>(Context);
        }
        //Obtener los mensajes que ha enviado el profesor.
        [HttpGet("{id}")]
        public IEnumerable<Mensaje> Get(int id)
        {
            var listaAlumnos_Mensajes = repositoryAlumno_Mensaje.GetAll().Where(x => x.FkIdAlumno == id).ToList();
            var listaTablaMensajes = repositoryMensajes.GetAll().ToList();
            foreach (var alumno_mensaje in listaAlumnos_Mensajes)
            {
                foreach (var mensaje in listaTablaMensajes)
                {
                    if (alumno_mensaje.FkIdMensaje == mensaje.Id)
                    {
                        listaMensajes.Add(mensaje);
                    }
                }
               
            }
            return listaMensajes;
        }
    }
}
