using EctoTecBackEnd.BL.Interfaces;
using EctoTecBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EctoTecBackEnd.BL.Services
{
    public class UsuarioService : IUsuario
    {
        public async Task<Respuesta<Usuario>> Agregar(Usuario Usuario)
        {

            string body = @"<style>
                            h1{color:dodgerblue;}
                            h2{color:darkorange;}
                            </style>
                            <h1>Correo enviado desde formulario en Angular</h1></br>";          



            Respuesta<Usuario> Respuesta = new Respuesta<Usuario>();
            Correo correo = new Correo();
            try
            {
                using (EctoTecContext Ctx = new EctoTecContext())
                {
                    await Ctx.Usuarios.AddAsync(Usuario);
                    await Ctx.SaveChangesAsync();

                    correo.sendMail(Usuario.Email, "Correo enviado desde aplicación de evaluación EctoTec}", body);

                    
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
