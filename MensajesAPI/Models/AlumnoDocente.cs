using System;
using System.Collections.Generic;

namespace MensajesAPI.Models
{
    public partial class AlumnoDocente
    {
        public int Id { get; set; }
        public int FkIdAlumno { get; set; }
        public int FkIdDocente { get; set; }

        public virtual Alumno FkIdAlumnoNavigation { get; set; } = null!;
        public virtual Docente FkIdDocenteNavigation { get; set; } = null!;
    }
}
