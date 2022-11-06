using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MensajesAPI.Models
{
    public partial class Especialidad
    {
        public Especialidad()
        {
            Alumno = new HashSet<Alumno>();
            DocenteEspecialidad = new HashSet<DocenteEspecialidad>();
            EspecialidadMensaje = new HashSet<EspecialidadMensaje>();
            Grupo = new HashSet<Grupo>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Alumno> Alumno { get; set; }
        [JsonIgnore]
        public virtual ICollection<DocenteEspecialidad> DocenteEspecialidad { get; set; }
        [JsonIgnore]
        public virtual ICollection<EspecialidadMensaje> EspecialidadMensaje { get; set; }
        [JsonIgnore]
        public virtual ICollection<Grupo> Grupo { get; set; }
    }
}
