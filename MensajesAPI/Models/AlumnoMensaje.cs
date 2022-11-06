using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MensajesAPI.Models
{
    public partial class AlumnoMensaje
    {
        public int Id { get; set; }
        public int FkIdAlumno { get; set; }
        public int FkIdMensaje { get; set; }

        [JsonIgnore]
        public virtual Alumno FkIdAlumnoNavigation { get; set; } = null!;
        [JsonIgnore]
        public virtual Mensaje FkIdMensajeNavigation { get; set; } = null!;
    }
}
