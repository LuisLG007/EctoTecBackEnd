using System;
using System.Collections.Generic;

#nullable disable

namespace EctoTecBackEnd.Models
{
    public partial class Estado
    {
        public int Idestado { get; set; }
        public string EstadoNombre { get; set; }
        public int Idpais { get; set; }
    }
}
