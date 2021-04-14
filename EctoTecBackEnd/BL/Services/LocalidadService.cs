using EctoTecBackEnd.BL.Interfaces;
using EctoTecBackEnd.DTOs;
using EctoTecBackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EctoTecBackEnd.BL.Services
{
    public class LocalidadService : ILocalidad
    {
        public async Task<Respuesta<List<LocalidadDTO>>> ObtenerLocalidades()
        {           
            Respuesta<List<LocalidadDTO>> Respuesta = new Respuesta<List<LocalidadDTO>>();
            try
            {
                using (EctoTecContext Ctx = new EctoTecContext())
                {
                    List<Ciudad> ciudad = await Ctx.Ciudades.ToListAsync();
                    List<Estado> estado = await Ctx.Estados.ToListAsync();
                    List<Pais> pais = await Ctx.Paises.ToListAsync();



                    var temp = from c in Ctx.Ciudades
                               join e in Ctx.Estados on c.Idestado equals e.Idestado
                               join p in Ctx.Paises on e.Idpais equals p.Idpais
                               select new LocalidadDTO
                               {
                                   Idciudad = c.Idciudad,
                                   CiudadNombre = c.CiudadNombre,
                                   EstadoNombre = e.EstadoNombre,
                                   PaisNombre = p.PaisNombre
                               };




                    Respuesta.Datos = new List<LocalidadDTO>();
                    Respuesta.Datos.AddRange((IEnumerable<LocalidadDTO>)temp);
                    Respuesta.bandera = true;
                }
            }
            catch (Exception ex)
            {

                Respuesta.mensaje = ex.Message;
                Respuesta.bandera = false;
            }

            return Respuesta;
        }
    }
}
