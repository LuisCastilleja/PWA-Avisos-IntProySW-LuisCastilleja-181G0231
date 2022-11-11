using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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

        [JsonIgnore]
        public virtual Docente? FkIdDocenteNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<AlumnoMensaje> AlumnoMensaje { get; set; }
        [JsonIgnore]
        public virtual ICollection<EspecialidadMensaje> EspecialidadMensaje { get; set; }
        [JsonIgnore]
        public virtual ICollection<GrupoMensaje> GrupoMensaje { get; set; }
    }
}
