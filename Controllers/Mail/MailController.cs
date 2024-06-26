using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FiltroApi.Models;

namespace PracticaFiltro.Controllers.Mail
{
    public class MailController
    {
        public async void SendEmail(string toEmail, string toName, string courseName, string courseDescription, string courseSchedule, string courseDuration, int? courseCapacity, string courseTeacher, string courseStatus)
        {   
            try
            {
                /* Url proporcionada por mailersend */
                string url = "https://api.mailersend.com/v1/email";

                // Token para autorización del mailersend
                string jwtToken = "mlsn.9a86bc451369998ba89de0b6c8e73782b348ea47cf903885ee3eed472baff82d";

                /* Colocamos el mensaje del email */
                var EmailMessage = new Email
                {
                    /* Email que proporciona MailerSend */
                    from = new From { email = "MS_GXlEIi@trial-jpzkmgqy0dyl059v.mlsender.net"},

                    /* A que persona se le va a enviar el email */
                    to = [
                        new To {email = toEmail}
                    ],

                    /* Contenido del correo */
                    subject = $"Felicidades, te has matrículado a un nuevo curso: {courseName}", /* Asunto del correo */

                    text = $"¡Hola, {toName} recientemente tu matrícula para el curso {courseName} ha sido aceptada!\nEstado de la matrícula: {courseStatus}\n\nDETALLES DEL CURSO\nNombre: {courseName}\nDescripcion: {courseDescription}\nHorario: {courseSchedule}\nDuración de las clases: {courseDuration}\nCapacidad Máxima: {courseCapacity} Estudiantes\nProfesor: {courseTeacher}"
                };

                /* Serializar el email */
                string jsonBody = JsonSerializer.Serialize(EmailMessage);

                 // Config cliente que va a enviar el correo
                using(HttpClient client = new HttpClient())
                {
                    // Autorización por el token del jwt
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwtToken}");

                    StringContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                    // Respuesta que nos devuelve
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    // Verificación de la respuesta en que casos nos sirve y que mostrar
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Se ha enviado correctamente el correo a {toEmail} con el asunto:\n{EmailMessage.text}");
                    } else
                    {
                        Console.WriteLine($"La solicitud falló: {response.StatusCode}");
                    }
                }
            }
            catch (Exception e) { }
        }
    }
}