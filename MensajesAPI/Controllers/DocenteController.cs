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

        public DocenteController(Proyecto_mensajes_pwa_bdContext context, IConfiguration configuration)
        {
            Context = context;
            Configuration = configuration;
            repositoryMensaje = new Repository<Mensaje>(Context);
        }
        //Obtener los mensajes que ha enviado el profesor.
        [HttpGet("{id}")]
        public IEnumerable<Mensaje> Get(int id)
        {
            return repositoryMensaje.GetAll().Where(x => x.FkIdDocente == id);
        }
    }
}
