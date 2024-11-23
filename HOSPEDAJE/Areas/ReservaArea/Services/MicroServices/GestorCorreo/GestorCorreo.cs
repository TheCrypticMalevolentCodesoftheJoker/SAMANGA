using MailKit.Net.Smtp;
using MimeKit;
using HOSPEDAJE.Areas.ReservaArea.Payloads.MensajesDTO;

namespace HOSPEDAJE.Areas.ReservaArea.Services.MicroServices.GestorCorreo
{
    public class GestorCorreo : IGestorCorreo
    {
        private readonly IConfiguration _configuration;

        public GestorCorreo(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<MensajeEstandarDTO> EmitirCorreo(string correoDestino)
        {
            var smtpSettings = _configuration.GetSection("SmtpSettings");

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Reserva", smtpSettings["SmtpFrom"]));
            message.To.Add(new MailboxAddress("", correoDestino));
            message.Subject = "Confirmación de Reserva";
            message.Body = new TextPart("plain")
            {
                Text = "Tu reserva ha sido registrada correctamente."
            };

            try
            {
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(smtpSettings["SmtpServer"], int.Parse(smtpSettings["SmtpPort"]), false);
                    await client.AuthenticateAsync(smtpSettings["SmtpUser"], smtpSettings["SmtpPassword"]);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }

                return new MensajeEstandarDTO(true, "Correo enviado exitosamente.");
            }
            catch (Exception ex)
            {
                return new MensajeEstandarDTO(false, $"Error al enviar el correo: {ex.Message}");
            }
        }
    }

}
