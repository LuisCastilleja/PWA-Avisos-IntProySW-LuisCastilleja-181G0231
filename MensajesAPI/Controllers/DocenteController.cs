using MensajesAPI.Models;
using MensajesAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace MensajesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class DocenteController : ControllerBase
    {
        public itesrcne_pwa_mensajes_181g0231_bdContext Context { get; }
        public IConfiguration Configuration { get; }

        Repository<Mensaje> repositoryMensaje;
        Repository<Especialidad> repositoryEspecialidad;
        Repository<Alumno> repositoryAlumno;
        Repository<Grupo> repositoryGrupo;
        Repository<Docente> repositoryDocente;
        Repository<DocenteEspecialidad> repositoryDocente_Especialidad;
        Repository<DocenteGrupo> repositoryDocente_Grupo;
        Repository<AlumnoMensaje> repositoryAlumno_Mensaje;
        Repository<GrupoMensaje> repositoryGrupo_Mensaje;
        Repository<EspecialidadMensaje> repositoryEspecialidad_Mensaje;
        Repository<AlumnoDocente> repositoryAlumno_Docente;
        List<Mensaje> listaMensajes = new List<Mensaje>();
        List<DocenteGrupo> listaDocente_Grupo = new List<DocenteGrupo>();
        List<DocenteEspecialidad> listaDocente_Especialidad = new List<DocenteEspecialidad>();
        List<Especialidad> listaTablaEspecialidad = new List<Especialidad>();
        List<Grupo> listaTablaGrupos = new List<Grupo>();
        List<Alumno> listaTablaAlumnos = new List<Alumno>();
        List<AlumnoDocente> listaAlumno_Docente = new List<AlumnoDocente>();
        List<Especialidad> listaEspecialidades = new List<Especialidad>();
        List<Grupo> listaGrupos = new List<Grupo>();
        List<Alumno> listaAlumnos = new List<Alumno>();
        Mensaje detallesMesajeVacio = new Mensaje();
        

        public DocenteController(itesrcne_pwa_mensajes_181g0231_bdContext context, IConfiguration configuration)
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
            repositoryAlumno_Docente = new Repository<AlumnoDocente>(Context);         
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
            if(id > 0)
            {
                return repositoryMensaje.GetAll().Where(x => x.FkIdDocente == id);
            }
            else
            {
                return listaMensajes;
            }
        }

        [HttpGet("Especialidades/{id}")]
        public IEnumerable<Especialidad> GetEspecialidades(int id)
        {
            if (id > 0)
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
            else
            {
                return listaEspecialidades;
            }
        }


        [HttpGet("Grupos/{id}")]
        public IEnumerable<Grupo> GetGrupos(int id)
        {
            if (id > 0)
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
            else
            {
                return listaGrupos;
            }
        }


        [HttpGet("Alumnos/{id}")]
        public IEnumerable<Alumno> GetAlumnosByProffesorId(int id)
        {
            if (id > 0)
            {
                    listaAlumno_Docente = repositoryAlumno_Docente.GetAll().Where(x => x.FkIdDocente == id).ToList();
                    listaTablaAlumnos = repositoryAlumno.GetAll().ToList();        
                
                if (listaAlumno_Docente != null && listaTablaAlumnos != null)
                {
                    foreach (var alumno_docente in listaAlumno_Docente)
                    {
                        foreach (var alumno in listaTablaAlumnos)
                        {
                            if (alumno_docente.FkIdAlumno == alumno.Id)
                            {
                                listaAlumnos.Add(alumno);
                            }
                        }
                    }
                }
                return listaAlumnos;
            }
            else
            {
                return listaAlumnos;
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Mensaje mensaje)
        {
            if(mensaje == null)
            {
                return BadRequest();
            }
            if(string.IsNullOrWhiteSpace(mensaje.MensajeEnviado))
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
            if(mensaje.FkIdDocente <= 0)
            {
                return BadRequest();
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
                //Ya cuando agrego la informacion a las tablas regresamos el Ok
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost("EditarMensaje")]
        public IActionResult Put([FromBody] Mensaje mensaje)
        {
            if (mensaje == null)
            {
                return BadRequest();
            }
            //Buscar el mensaje a editar
            var mensajeBdEditar = repositoryMensaje.GetAll().FirstOrDefault(x => x.Id == mensaje.Id);
            //Sino encuentra el mensaje
            if (mensajeBdEditar == null)
            {
                return NotFound();
            }
            else
            {
                //Si encuentra el mensaje validamos que sus propiedades no esten vacias
                if (string.IsNullOrWhiteSpace(mensaje.MensajeEnviado))
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
                if (mensaje.FkIdDocente <= 0)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    //Recibimos la lista de destinatarios que edito y lo hacemos un arreglo de strings
                    string[] destinatariosRecibidos = mensaje.Destinatarios.Split(',');
                    //Compararemos los destinatarios que recibimos con los que ya teniamos en el mensaje de la base de datos para ver cuales cambiaremos
                    string[] destintariosMensajeBd = mensajeBdEditar.Destinatarios.Split(',');

                    //Lista de destinatarios que agregaremos o eliminaremos 
                    List<string> listDestintarios = new List<string>();
                    //Inicializamos la lista de los destinatarios a agregar con los que nos paso el usuario
                    foreach (var destintario in destinatariosRecibidos)
                    {
                        listDestintarios.Add(destintario);
                    }
                    List<string> destinatariosNuevosAgregar = new List<string>();
                    List<string> destinatariosEliminar = new List<string>();

                    //Foreach para buscar los nuevos destinatarios que vamos a agregar
                    foreach (var nuevoDestinatario in destinatariosRecibidos)
                    {
                        //SI la lista donde estan destinarios antiguos no contiene el nuevo destinatario lo agregamos
                        if (!destintariosMensajeBd.Contains(nuevoDestinatario))
                        {
                            //Lo agregamos al arreglo
                            destinatariosNuevosAgregar.Add(nuevoDestinatario);
                        }
                    }

                    //Recorremos la lista de destintarios antigua para ver si los destintarios que tenia aun siguen estando
                    foreach (var destintarioBd  in  destintariosMensajeBd)
                    {
                        //SI la lista donde estan destinarios antiguos no contiene el nuevo destinatario lo agregamos a la lista
                        //De los que se eliminaran
                        if (!listDestintarios.Contains(destintarioBd))
                        {
                            //Lo agregamos al arreglo
                            destinatariosEliminar.Add(destintarioBd);
                        }
                    }

                    //ESTE FOREACH ES PARA ELIMINAR LOS DESTINTARIOS QUE ELIMINO EL USUARIO Y LOS BORRAREMOS DE TODAS LAS TABLAS.
                    foreach (var destinatario in destinatariosEliminar)
                    {
                        //Si el destintario contiene la palabra Ing. lo eliminaremos de la tabla Especialidad_Mensaje
                        if (destinatario.Contains("Ing."))
                        {
                            var especialidad = repositoryEspecialidad.GetAll().FirstOrDefault(x => x.Nombre == destinatario);
                            if (especialidad != null)
                            {
                                var especialidad_mensajeEliminar = repositoryEspecialidad_Mensaje.GetAll()
                                .FirstOrDefault(x => x.FkIdEspecialidad == especialidad.Id && x.FkIdMensaje == mensajeBdEditar.Id);
                                //Si encontro el objeto que eliminara en la tabla especialidad_mensaje;
                                if (especialidad_mensajeEliminar != null)
                                {
                                    //Lo eliminamos de la tabla
                                    repositoryEspecialidad_Mensaje.Delete(especialidad_mensajeEliminar);
                                }
                            }                     
                        }
                        //Si contiene un numero, despues un punto y otro numero quiere decir que es un grupo y lo eliminaremos
                        //De la tabla Grupo_Mensaje
                        else if (new Regex("[0-9]").IsMatch(destinatario))
                        {
                            var grupo = repositoryGrupo.GetAll().FirstOrDefault(x => x.Nombre == destinatario);
                            if (grupo != null)
                            {
                                var grupo_mensajeEliminar = repositoryGrupo_Mensaje.GetAll()
                                    .FirstOrDefault(x=>x.FkIdGrupo == grupo.Id && x.FkIdMensaje == mensajeBdEditar.Id);

                                //Si encontro el objeto que eliminara en la tabla de grupo_mensaje
                                if (grupo_mensajeEliminar != null)
                                {
                                    //Lo eliminamos de la tabla
                                    repositoryGrupo_Mensaje.Delete(grupo_mensajeEliminar);
                                }
                            }
                        }
                        //Sino, quiere decir que es un alumno y lo eliminaremos de la tabla Alumno_Mensaje
                        else
                        {
                            var alumno = repositoryAlumno.GetAll().FirstOrDefault(x => x.NombreCompleto == destinatario);
                            if (alumno != null)
                            {
                                var alumno_mensajeEliminar = repositoryAlumno_Mensaje.GetAll()
                                    .FirstOrDefault(x=>x.FkIdAlumno == alumno.Id && x.FkIdMensaje == mensajeBdEditar.Id);
                                //Si encontro el objeto que eliminara en la tabla de alumno_mensaje
                                if (alumno_mensajeEliminar != null)
                                {
                                    repositoryAlumno_Mensaje.Delete(alumno_mensajeEliminar);
                                }
                            }
                        }
                    }


                    //ESTE FOREACH ES PARA AGREGAR LOS DESTINTARIOS NUEVOS QUE AGREGO EL USUARIO Y LOS AGREGARMOS A TODAS LAS TABLAS.
                    foreach (var destinatario in destinatariosNuevosAgregar)
                        {
                            //Si el destintario contiene la palabra Ing. lo agregaremos a la tabla Especialidad_Mensaje
                            if (destinatario.Contains("Ing."))
                            {
                                var especialidad = repositoryEspecialidad.GetAll().FirstOrDefault(x => x.Nombre == destinatario);
                                if (especialidad != null)
                                {
                                    EspecialidadMensaje especialidad_mensaje = new EspecialidadMensaje()
                                    {
                                        FkIdMensaje = mensajeBdEditar.Id,
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
                                        FkIdMensaje = mensajeBdEditar.Id
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
                                        FkIdMensaje = mensajeBdEditar.Id
                                    };
                                    repositoryAlumno_Mensaje.Insert(alumno_mensaje);
                                }
                            }
                        }

                    //Cambiamos los datos del mensaje que teniamos en la bd por los datos del mensaje nuevo que nos enviaron.
                    mensajeBdEditar.MensajeEnviado = mensaje.MensajeEnviado;
                    mensajeBdEditar.Destinatarios = mensaje.Destinatarios;
                    mensajeBdEditar.Asunto = mensaje.Asunto;

                    //Actualizamos el mensaje que teniamos en la bd con la nueva informacion.
                    repositoryMensaje.Update(mensajeBdEditar);
                    //Ya cuando termino de agregar y eliminar datos en las tablas correspondientes devolvemos el Ok
                    return Ok();
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            else
            {
                var mensajeEliminar = repositoryMensaje.GetById(id);
                if (mensajeEliminar != null)
                {
                    //Buscamos en la tabla especialidad_mensaje el mensaje que se eliminara por el id del mensaje
                    var listaEliminarEspecialidad_mensajeEliminar = repositoryEspecialidad_Mensaje.GetAll().Where(x => x.FkIdMensaje == id).ToList();
                    //Buscamos en la tabla alumno_mensaje el mensaje que se eliminara por el id del mensaje
                    var listaEliminarAlumno_mensaje = repositoryAlumno_Mensaje.GetAll().Where(x => x.FkIdMensaje == id).ToList();
                    //Buscamos en la tabla grupo_mensaje el mensaje que se eliminara por el id del mensaje
                    var listaEliminarGrupo_mensaje = repositoryGrupo_Mensaje.GetAll().Where(x => x.FkIdMensaje == id).ToList();

                    //Si hay mensajes en la tabla especialidad_mensaje por eliminar
                    if(listaEliminarEspecialidad_mensajeEliminar != null)
                    {
                        //Recorremos la lista que tiene los mensajes a eliminar
                        foreach (var eliminarMensaje in listaEliminarEspecialidad_mensajeEliminar)
                        {
                            //Lo eliminamos de la bd
                            repositoryEspecialidad_Mensaje.Delete(eliminarMensaje);
                        }
                    }
                    //Si hay mensajes en la tabla alumno_mensaje por eliminar
                    if (listaEliminarAlumno_mensaje != null)
                    {
                        //Recorremos la lista que tiene los mensajes a eliminar
                        foreach (var eliminarMensaje in listaEliminarAlumno_mensaje)
                        {
                            //Lo eliminamos de la bd
                            repositoryAlumno_Mensaje.Delete(eliminarMensaje);
                        }
                    }
                    //Si hay mensajes en la tabla grupo_mensaje por eliminar
                    if (listaEliminarGrupo_mensaje != null)
                    {
                        //Recorremos la lista que tiene los mensajes a eliminar
                        foreach (var eliminarMensaje in listaEliminarGrupo_mensaje)
                        {
                            //Lo eliminamos de la bd
                            repositoryGrupo_Mensaje.Delete(eliminarMensaje);
                        }
                    }


                    //Lo eliminamos de la tabla mensajes el mensaje que decidio eliminar el usuario
                    repositoryMensaje.Delete(mensajeEliminar);

                    //Cuando termine de eliminar en todas las tablas regresamos el Ok
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
        }

    }
}
