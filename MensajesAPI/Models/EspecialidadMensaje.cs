using System;
using System.Collections.Generic;

namespace MensajesAPI.Models
{
    public partial class EspecialidadMensaje
    {
        public int Id { get; set; }
        public int FkIdEspecialidad { get; set; }
        public int FkIdMensaje { get; set; }

        public virtual Especialidad FkIdEspecialidadNavigation { get; set; } = null!;
        public virtual Mensaje FkIdMensajeNavigation { get; set; } = null!;
    }
}
