using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MensajesAPI.Models
{
    public partial class DocenteGrupo
    {
        public int Id { get; set; }
        public int FkIdDocente { get; set; }
        public int FkIdGrupo { get; set; }

        [JsonIgnore]
        public virtual Docente FkIdDocenteNavigation { get; set; } = null!;
        [JsonIgnore]
        public virtual Grupo FkIdGrupoNavigation { get; set; } = null!;
    }
}
