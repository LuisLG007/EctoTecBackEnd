using EctoTecBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EctoTecBackEnd.BL.Interfaces
{
    public interface IUsuario
    {
        Task<Respuesta<Usuario>> Agregar(Usuario Usuario);
    }
}
