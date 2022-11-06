using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MensajesAPI.Models
{
    public partial class GrupoMensaje
    {
        public int Id { get; set; }
        public int FkIdGrupo { get; set; }
        public int FkIdMensaje { get; set; }

        [JsonIgnore]
        public virtual Grupo FkIdGrupoNavigation { get; set; } = null!;
        [JsonIgnore]
        public virtual Mensaje FkIdMensajeNavigation { get; set; } = null!;
    }
}
