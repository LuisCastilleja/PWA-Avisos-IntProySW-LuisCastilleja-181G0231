using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MensajesAPI.Models
{
    public partial class EspecialidadMensaje
    {
        public int Id { get; set; }
        public int FkIdEspecialidad { get; set; }
        public int FkIdMensaje { get; set; }

        [JsonIgnore]
        public virtual Especialidad FkIdEspecialidadNavigation { get; set; } = null!;
        [JsonIgnore]
        public virtual Mensaje FkIdMensajeNavigation { get; set; } = null!;
    }
}
