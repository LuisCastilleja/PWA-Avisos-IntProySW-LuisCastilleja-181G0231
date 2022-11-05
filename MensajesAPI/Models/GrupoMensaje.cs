using System;
using System.Collections.Generic;

namespace MensajesAPI.Models
{
    public partial class GrupoMensaje
    {
        public int Id { get; set; }
        public int FkIdGrupo { get; set; }
        public int FkIdMensaje { get; set; }

        public virtual Grupo FkIdGrupoNavigation { get; set; } = null!;
        public virtual Mensaje FkIdMensajeNavigation { get; set; } = null!;
    }
}
