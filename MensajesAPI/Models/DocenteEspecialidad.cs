using System;
using System.Collections.Generic;

namespace MensajesAPI.Models
{
    public partial class DocenteEspecialidad
    {
        public int Id { get; set; }
        public int FkIdDocente { get; set; }
        public int FkIdEspecialidad { get; set; }

        public virtual Docente FkIdDocenteNavigation { get; set; } = null!;
        public virtual Especialidad FkIdEspecialidadNavigation { get; set; } = null!;
    }
}
