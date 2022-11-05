using System;
using System.Collections.Generic;

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

        public virtual ICollection<Alumno> Alumno { get; set; }
        public virtual ICollection<DocenteEspecialidad> DocenteEspecialidad { get; set; }
        public virtual ICollection<EspecialidadMensaje> EspecialidadMensaje { get; set; }
        public virtual ICollection<Grupo> Grupo { get; set; }
    }
}
