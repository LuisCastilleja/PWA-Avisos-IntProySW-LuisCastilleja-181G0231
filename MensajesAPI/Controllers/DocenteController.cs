using MensajesAPI.Models;
using MensajesAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace MensajesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocenteController : ControllerBase
    {
        public Proyecto_mensajes_pwa_bdContext Context { get; }
        public IConfiguration Configuration { get; }

        Repository<Mensaje> repositoryMensaje;
        Repository<Especialidad> repositoryEspecialidad;
        Repository<Alumno> repositoryAlumno;
        Repository<Grupo> repositoryGrupo;
        Repository<Docente> repositoryDocente;
        Repository<DocenteEspecialidad> repositoryDocente_Especialidad;
        Repository<DocenteGrupo> repositoryDocente_Grupo;
        List<DocenteGrupo> listaDocente_Grupo = new List<DocenteGrupo>();
        List<DocenteEspecialidad> listaDocente_Especialidad = new List<DocenteEspecialidad>();
        List<Especialidad> listaTablaEspecialidad = new List<Especialidad>();
        List<Grupo> listaTablaGrupos = new List<Grupo>();
        List<Especialidad> listaEspecialidades = new List<Especialidad>();
        List<Grupo> listaGrupos = new List<Grupo>();
        Repository<AlumnoMensaje> repositoryAlumno_Mensaje;
        Repository<GrupoMensaje> repositoryGrupo_Mensaje;
        Repository<EspecialidadMensaje> repositoryEspecialidad_Mensaje;

        public DocenteController(Proyecto_mensajes_pwa_bdContext context, IConfiguration configuration)
        {
            Context = context;
            Configuration = configuration;
            repositoryMensaje = new Repository<Mensaje>(Context);
            repositoryEspecialidad = new Repository<Especialidad>(Context);
            repositoryGrupo = new Repository<Grupo>(Context);
            repositoryDocente = new Repository<Docente>(Context);
            repositoryDocente_Especialidad = new Repository<DocenteEspecialidad>(Context);
            repositoryDocente_Grupo = new Repository<DocenteGrupo>(Context);
            repositoryAlumno_Mensaje = new Repository<AlumnoMensaje>(Context);
            repositoryGrupo_Mensaje = new Repository<GrupoMensaje>(Context);
            repositoryEspecialidad_Mensaje = new Repository<EspecialidadMensaje>(Context);
            repositoryAlumno = new Repository<Alumno>(Context);
            
        }
        //Obtener los mensajes que ha enviado el profesor.
        [HttpGet("{id}")]
        public IEnumerable<Mensaje> Get(int id)
        {
            return repositoryMensaje.GetAll().Where(x => x.FkIdDocente == id);
        }

        [HttpGet("Especialidades/{id}")]
        public IEnumerable<Especialidad> GetEspecialidades(int id)
        {
            Docente docente = repositoryDocente.GetById(id);
            if (docente != null)
            {
                listaDocente_Especialidad = repositoryDocente_Especialidad.GetAll().Where(x => x.FkIdDocente == docente.Id).ToList();
                listaTablaEspecialidad = repositoryEspecialidad.GetAll().ToList();
            }
            if (listaDocente_Especialidad != null && listaTablaEspecialidad != null)
            {
                foreach (var docente_Especialidad in listaDocente_Especialidad)
                {
                    foreach (var especialidad in listaTablaEspecialidad)
                    {
                        if (docente_Especialidad.FkIdEspecialidad == especialidad.Id)
                        {
                            listaEspecialidades.Add(especialidad);
                        }
                    }
                }
            }
            return listaEspecialidades;
        }
        
        
        [HttpGet("Grupos/{id}")]
        public IEnumerable<Grupo> GetGrupos(int id)
        {
            Docente docente = repositoryDocente.GetById(id);
            if (docente != null)
            {
                listaDocente_Grupo = repositoryDocente_Grupo.GetAll().Where(x => x.FkIdDocente == docente.Id).ToList();
                listaTablaGrupos = repositoryGrupo.GetAll().ToList();
            }
            if (listaDocente_Grupo != null && listaTablaGrupos != null)
            {
                foreach (var docente_grupo in listaDocente_Grupo)
                {
                    foreach (var grupo in listaTablaGrupos)
                    {
                        if (docente_grupo.FkIdGrupo == grupo.Id)
                        {
                            listaGrupos.Add(grupo);
                        }
                    }
                }
            }
            return listaGrupos;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Mensaje mensaje)
        {
            if(mensaje == null)
            {
                return BadRequest();
            }
            if(string.IsNullOrWhiteSpace(mensaje.Mensaje1))
            {
                ModelState.AddModelError("", "Proporcione el mensaje a enviar");
            }
            if (string.IsNullOrWhiteSpace(mensaje.Asunto))
            {
                ModelState.AddModelError("", "Proporcione el asunto a enviar");
            }
            if (string.IsNullOrWhiteSpace(mensaje.Destinatarios))
            {
                ModelState.AddModelError("", "Proporcione los destinatarios del mensaje");
            }
            if (ModelState.IsValid)
            {
                //Agregamos el mensaje nuevo a la tabla mensajes
                repositoryMensaje.Insert(mensaje);
                //Buscamos el mensaje que acabamos de agregar para obtener su id y para agregarlo a las demas tablas
                var mensajeRecienAgregado = repositoryMensaje.GetAll().Last();
                if (mensajeRecienAgregado != null)
                {
                    //Recibimos la lista de destinatarios y lo hacemos un arreglo de strings
                    string[] destinatarios = mensaje.Destinatarios.Split(',');
                    foreach (var destinatario in destinatarios)
                    {
                        //Si el destintario contiene la palabra Ing. lo agregaremos a la tabla Especialidad_Mensaje
                        if (destinatario.Contains("Ing."))
                        {
                            var especialidad = repositoryEspecialidad.GetAll().FirstOrDefault(x => x.Nombre == destinatario);
                            if (especialidad != null)
                            {
                                EspecialidadMensaje especialidad_mensaje = new EspecialidadMensaje()
                                {
                                    FkIdMensaje = mensajeRecienAgregado.Id,
                                    FkIdEspecialidad = especialidad.Id
                                };
                                repositoryEspecialidad_Mensaje.Insert(especialidad_mensaje);
                            }
                        }
                        //Si contiene un numero, despues un punto y otro numero quiere decir que es un grupo y lo agregaremos
                        //A la tabla Grupo_Mensaje
                        else if (new Regex("[0-9]").IsMatch(destinatario))
                        {
                            var grupo = repositoryGrupo.GetAll().FirstOrDefault(x => x.Nombre == destinatario);
                            if (grupo != null)
                            {
                                GrupoMensaje grupo_mensaje = new GrupoMensaje()
                                {
                                    FkIdGrupo = grupo.Id,
                                    FkIdMensaje = mensajeRecienAgregado.Id
                                };
                                repositoryGrupo_Mensaje.Insert(grupo_mensaje);
                            }
                        }
                        //Sino, quiere decir que es un alumno y lo agregamos a la tabla Alumno_Mensaje
                        else
                        {
                            var alumno = repositoryAlumno.GetAll().FirstOrDefault(x => x.NombreCompleto == destinatario);
                            if (alumno != null)
                            {
                                AlumnoMensaje alumno_mensaje = new AlumnoMensaje()
                                {
                                    FkIdAlumno = alumno.Id,
                                    FkIdMensaje = mensajeRecienAgregado.Id
                                };
                                repositoryAlumno_Mensaje.Insert(alumno_mensaje);
                            }
                        }
                    }
                }
                //Insertar a todas las tablas correspondientes
                //Extraer los destinatarios en una lista y luego recorrerla para separar por grupo, especialidad y alumno.
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
