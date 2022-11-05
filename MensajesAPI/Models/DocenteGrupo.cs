using System;
using System.Collections.Generic;

namespace MensajesAPI.Models
{
    public partial class DocenteGrupo
    {
        public int Id { get; set; }
        public int FkIdDocente { get; set; }
        public int FkIdGrupo { get; set; }

        public virtual Docente FkIdDocenteNavigation { get; set; } = null!;
        public virtual Grupo FkIdGrupoNavigation { get; set; } = null!;
    }
}
