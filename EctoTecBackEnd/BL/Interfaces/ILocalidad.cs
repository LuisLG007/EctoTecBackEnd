using EctoTecBackEnd.DTOs;
using EctoTecBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EctoTecBackEnd.BL.Interfaces
{
    public interface ILocalidad
    {
        Task<Respuesta<List<LocalidadDTO>>> ObtenerLocalidades();
    }
}
