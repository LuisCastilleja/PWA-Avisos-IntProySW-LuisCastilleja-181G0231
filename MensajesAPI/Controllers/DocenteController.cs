using MensajesAPI.Models;
using MensajesAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
