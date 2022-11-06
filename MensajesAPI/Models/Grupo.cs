using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MensajesAPI.Models
{
    public partial class Grupo
    {
        public Grupo()
        {
            Alumno = new HashSet<Alumno>();
            DocenteGrupo = new HashSet<DocenteGrupo>();
            GrupoMensaje = new HashSet<GrupoMensaje>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int FkIdEspecialidad { get; set; }

        [JsonIgnore]
        public virtual Especialidad FkIdEspecialidadNavigation { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Alumno> Alumno { get; set; }
        [JsonIgnore]
        public virtual ICollection<DocenteGrupo> DocenteGrupo { get; set; }
        [JsonIgnore]
        public virtual ICollection<GrupoMensaje> GrupoMensaje { get; set; }
    }
}
