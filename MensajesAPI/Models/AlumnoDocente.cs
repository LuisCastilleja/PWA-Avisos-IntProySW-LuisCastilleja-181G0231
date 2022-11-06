using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MensajesAPI.Models
{
    public partial class AlumnoDocente
    {
        public int Id { get; set; }
        public int FkIdAlumno { get; set; }
        public int FkIdDocente { get; set; }
        [JsonIgnore]
        public virtual Alumno FkIdAlumnoNavigation { get; set; } = null!;
        [JsonIgnore]
        public virtual Docente FkIdDocenteNavigation { get; set; } = null!;
    }
}
