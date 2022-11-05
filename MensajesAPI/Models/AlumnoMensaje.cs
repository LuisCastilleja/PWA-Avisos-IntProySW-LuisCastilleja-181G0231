using System;
using System.Collections.Generic;

namespace MensajesAPI.Models
{
    public partial class AlumnoMensaje
    {
        public int Id { get; set; }
        public int FkIdAlumno { get; set; }
        public int FkIdMensaje { get; set; }

        public virtual Alumno FkIdAlumnoNavigation { get; set; } = null!;
        public virtual Mensaje FkIdMensajeNavigation { get; set; } = null!;
    }
}
