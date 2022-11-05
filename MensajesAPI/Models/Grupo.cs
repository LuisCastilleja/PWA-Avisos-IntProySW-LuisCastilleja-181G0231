using System;
using System.Collections.Generic;

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

        public virtual Especialidad FkIdEspecialidadNavigation { get; set; } = null!;
        public virtual ICollection<Alumno> Alumno { get; set; }
        public virtual ICollection<DocenteGrupo> DocenteGrupo { get; set; }
        public virtual ICollection<GrupoMensaje> GrupoMensaje { get; set; }
    }
}
