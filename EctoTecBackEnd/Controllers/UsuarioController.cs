using EctoTecBackEnd.BL.Interfaces;
using EctoTecBackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EctoTecBackEnd.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUsuario UsuarioService;

        public UsuarioController(IUsuario _UsuarioService)
        {
            this.UsuarioService = _UsuarioService;
        }


        [HttpPost("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] Usuario Usuario)
        {
            if (Usuario.Id == Guid.Empty)
            {
                Usuario.Id = Guid.NewGuid();
            }
            Respuesta<Usuario> Respuesta = new Respuesta<Usuario>();
            try
            {
                Respuesta = await this.UsuarioService.Agregar(Usuario);
                return Ok(Respuesta);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
    }
}
