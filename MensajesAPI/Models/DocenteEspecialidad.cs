using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MensajesAPI.Models
{
    public partial class DocenteEspecialidad
    {
        public int Id { get; set; }
        public int FkIdDocente { get; set; }
        public int FkIdEspecialidad { get; set; }

        [JsonIgnore]
        public virtual Docente FkIdDocenteNavigation { get; set; } = null!;
        [JsonIgnore]
        public virtual Especialidad FkIdEspecialidadNavigation { get; set; } = null!;
    }
}
