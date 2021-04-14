using System;
using System.Collections.Generic;

#nullable disable

namespace EctoTecBackEnd.Models
{
    public partial class Ciudad
    {
        public int Idciudad { get; set; }
        public string CiudadNombre { get; set; }
        public int Idestado { get; set; }
    }
}
