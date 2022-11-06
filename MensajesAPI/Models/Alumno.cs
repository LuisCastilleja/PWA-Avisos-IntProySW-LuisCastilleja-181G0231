using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MensajesAPI.Models
{
    public partial class Alumno
    {
        public Alumno()
        {
            AlumnoDocente = new HashSet<AlumnoDocente>();
            AlumnoMensaje = new HashSet<AlumnoMensaje>();
        }

        public int Id { get; set; }
        public string NombreCompleto { get; set; } = null!;
        public string NumeroControl { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public int FkIdGrupo { get; set; }
        public int FkIdEspecialidad { get; set; }
        [JsonIgnore]
        public virtual Especialidad FkIdEspecialidadNavigation { get; set; } = null!;
        [JsonIgnore]
        public virtual Grupo FkIdGrupoNavigation { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<AlumnoDocente> AlumnoDocente { get; set; }
        [JsonIgnore]
        public virtual ICollection<AlumnoMensaje> AlumnoMensaje { get; set; }
    }
}
