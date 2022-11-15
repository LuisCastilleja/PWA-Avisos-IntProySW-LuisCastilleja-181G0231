using MensajesAPI.Models;
using MensajesAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MensajesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AlumnoController : ControllerBase
    {
        public Proyecto_mensajes_pwa_bdContext Context { get; }
        public IConfiguration Configuration { get; }

        Repository<AlumnoMensaje> repositoryAlumno_Mensaje;
        Repository<Mensaje> repositoryMensaje;
        Repository<EspecialidadMensaje> repositoryEspecialidad_Mensaje;
        Repository<GrupoMensaje> repositoryGrupo_Mensaje;
        Repository<Alumno> repositoryAlumno;
        List<Mensaje> listaMensajes = new List<Mensaje>();
        List<AlumnoMensaje> listaAlumnos_Mensajes = new List<AlumnoMensaje>();
        List<Mensaje> listaTablaMensajes = new List<Mensaje>();
        List<EspecialidadMensaje> listaEspecialidad_Mensajes = new List<EspecialidadMensaje>();
        List<GrupoMensaje> listaGrupo_Mensajes = new List<GrupoMensaje>();
        Mensaje detallesMesajeVacio = new Mensaje();

        public AlumnoController(Proyecto_mensajes_pwa_bdContext context, IConfiguration configuration)
        {
            Context = context;
            Configuration = configuration;
            repositoryMensaje = new Repository<Mensaje>(Context);
            repositoryAlumno_Mensaje = new Repository<AlumnoMensaje>(Context);
            repositoryEspecialidad_Mensaje = new Repository<EspecialidadMensaje>(Context);
            repositoryGrupo_Mensaje = new Repository<GrupoMensaje>(Context);
            repositoryAlumno = new Repository<Alumno>(Context);
        }

        [HttpGet("DetallesMensaje/{id}")]
        public Mensaje GetDetailsOfMessageById(int id)
        {
            if (id > 0)
            {
                //Buscamos el mensaje en la bd
                var detallesMensaje = repositoryMensaje.GetAll().FirstOrDefault(x => x.Id == id);
                //Si lo encuentra lo regresamos
                if (detallesMensaje != null)
                {
                    return detallesMensaje;
                }
                else
                {

                    //Sino encuentra un mensaje devolvemos uno vacio
                    return detallesMesajeVacio;
                }
            }
            else
            {
                return detallesMesajeVacio;
            }
        }

        //Obtener los mensajes que ha enviado el profesor.
        [HttpGet("{id}")]
        public IEnumerable<Mensaje> Get(int id)
        {
            if (id > 0)
            {
                var alumno = repositoryAlumno.GetById(id);
                if (alumno != null)
                {
                    listaTablaMensajes = repositoryMensaje.GetAll().ToList();
                    listaAlumnos_Mensajes = repositoryAlumno_Mensaje.GetAll().Where(x => x.FkIdAlumno == alumno.Id).ToList();
                    listaEspecialidad_Mensajes = repositoryEspecialidad_Mensaje.GetAll().Where(x => x.FkIdEspecialidad == alumno.FkIdEspecialidad).ToList();
                    listaGrupo_Mensajes = repositoryGrupo_Mensaje.GetAll().Where(x => x.FkIdGrupo == alumno.FkIdGrupo).ToList();
                }
                //Traer los mensajes que se le enviaron al alumno individualmente
                if (listaAlumnos_Mensajes != null && listaTablaMensajes != null)
                {
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
                }
                //Traer los mensajes que se le enviaron al alumno por grupo
                if (listaGrupo_Mensajes != null && listaTablaMensajes != null)
                {
                    foreach (var grupo_mensaje in listaGrupo_Mensajes)
                    {
                        foreach (var mensaje in listaTablaMensajes)
                        {
                            if (grupo_mensaje.FkIdMensaje == mensaje.Id)
                            {
                                listaMensajes.Add(mensaje);
                            }
                        }
                    }
                }
                //Traer los mesajes que se le enviaron al alumno por especialidad
                if (listaEspecialidad_Mensajes != null && listaTablaMensajes != null)
                {
                    foreach (var especialidad_mensaje in listaEspecialidad_Mensajes)
                    {
                        foreach (var mensaje in listaTablaMensajes)
                        {
                            if (especialidad_mensaje.FkIdMensaje == mensaje.Id)
                            {
                                listaMensajes.Add(mensaje);
                            }
                        }
                    }
                }
                return listaMensajes;
            }
            else
            {
                return listaMensajes;
            }

        }
    }
}
