using System;
using System.Collections.Generic;

namespace MensajesAPI.Models
{
    public partial class Mensaje
    {
        public Mensaje()
        {
            AlumnoMensaje = new HashSet<AlumnoMensaje>();
            EspecialidadMensaje = new HashSet<EspecialidadMensaje>();
            GrupoMensaje = new HashSet<GrupoMensaje>();
        }

        public int Id { get; set; }
        public string Asunto { get; set; } = null!;
        public string Mensaje1 { get; set; } = null!;
        public string Destinatarios { get; set; } = null!;
        public int FkIdDocente { get; set; }

        public virtual Docente FkIdDocenteNavigation { get; set; } = null!;
        public virtual ICollection<AlumnoMensaje> AlumnoMensaje { get; set; }
        public virtual ICollection<EspecialidadMensaje> EspecialidadMensaje { get; set; }
        public virtual ICollection<GrupoMensaje> GrupoMensaje { get; set; }
    }
}
