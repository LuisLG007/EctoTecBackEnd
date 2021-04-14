using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace EctoTecBackEnd.BL.Services
{
    class Correo
    {
        public string sendMail(string to, string asunto, string body)
        {
            string msge = "Error al enviar este correo. Por favor verifique los datos o intente más tarde.";
            string from = "LuisLSC@outlook.com";
            string displayName = "Luis Alberto López Gutiérrez";
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from, displayName);
                mail.To.Add(to);
                mail.CC.Add("LuisLSC@outlook.com");

                mail.Subject = asunto;
                mail.Body = body;
                mail.IsBodyHtml = true;


                SmtpClient client = new SmtpClient("smtp.office365.com", 587); //Aquí debes sustituir tu servidor SMTP y el puerto
                client.Credentials = new NetworkCredential(from, "ingran");
                client.EnableSsl = true;//En caso de que tu servidor de correo no utilice cifrado SSL,poner en false


                client.Send(mail);
                msge = "¡Correo enviado exitosamente! Pronto te contactaremos.";

            }
            catch (Exception ex)
            {
                msge = ex.Message + ". Por favor verifica tu conexión a internet y que tus datos sean correctos e intenta nuevamente.";
            }

            return msge;
        }
    }
}
