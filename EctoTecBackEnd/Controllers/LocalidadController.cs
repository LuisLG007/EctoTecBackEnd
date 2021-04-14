using EctoTecBackEnd.BL.Interfaces;
using EctoTecBackEnd.DTOs;
using EctoTecBackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EctoTecBackEnd.Controllers
{
    [Route("api/localidad")]
    [ApiController]
    public class LocalidadController : Controller
    {
        private readonly ILocalidad LocalidadService;

        public LocalidadController(ILocalidad _LocalidadService)
        {
            this.LocalidadService = _LocalidadService;
        }

        [HttpGet("ObtenerLocalidades")]
        public async Task<IActionResult> ObtenerLocalidades()
        {
            Respuesta<List<LocalidadDTO>> Respuesta = new Respuesta<List<LocalidadDTO>>();
            try
            {
                Respuesta = await this.LocalidadService.ObtenerLocalidades();
                return Ok(Respuesta);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
