using System;
using System.Collections.Generic;

namespace MensajesAPI.Models
{
    public partial class Docente
    {
        public Docente()
        {
            AlumnoDocente = new HashSet<AlumnoDocente>();
            DocenteEspecialidad = new HashSet<DocenteEspecialidad>();
            DocenteGrupo = new HashSet<DocenteGrupo>();
            Mensaje = new HashSet<Mensaje>();
        }

        public int Id { get; set; }
        public string NombreCompleto { get; set; } = null!;
        public string NumeroControl { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Contraseña { get; set; } = null!;

        public virtual ICollection<AlumnoDocente> AlumnoDocente { get; set; }
        public virtual ICollection<DocenteEspecialidad> DocenteEspecialidad { get; set; }
        public virtual ICollection<DocenteGrupo> DocenteGrupo { get; set; }
        public virtual ICollection<Mensaje> Mensaje { get; set; }
    }
}
