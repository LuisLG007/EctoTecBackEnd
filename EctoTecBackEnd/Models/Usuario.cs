using System;
using System.Collections.Generic;

#nullable disable

namespace EctoTecBackEnd.Models
{
    public partial class Usuario
    {
        public Guid? Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime? Fecha { get; set; }
        public int IdCiudad { get; set; }
    }
}
