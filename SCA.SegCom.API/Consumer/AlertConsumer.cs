using MassTransit;
using SCA.IntegrationEvents.Alert;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace SCA.SegCom.API.Consumer
{
    public class AlertConsumer : IConsumer<AlertarCommand>
    {
        public Task Consume(ConsumeContext<AlertarCommand> context)
        {
            var accountSid = "ACfb396c64d2ff9806b464acd3d7802a2a";
            var authToken = "8b5d23c75b7656c8b0ab0f711aae6bc5";
            Twilio.TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber("+5521980585439");
            var from = new PhoneNumber("+12184437178");

            var message = MessageResource.Create(to: to, from: from, body: context.Message.Mensagem);

            try
            {
                //var mailMsg = new MailMessage();

                //mailMsg.To.Add(new MailAddress("tiago.peterson@gmail.com", "The Recipient"));

                //mailMsg.From = new MailAddress("tiago.peterson@gmail.com", "The Sender");

                //mailMsg.Subject = "Test Email";
                //string text = "Test Email with SendGrid using .NET's Built-in SMTP Library";
                //string html = @"<strong>"+ context.Message.Mensagem + "</strong>";
                //mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
                //mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

                //SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
                //System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("azure_f6d2d00e0cfce923c9e88792b0f752d2@azure.com", "Theozin#3009");
                //smtpClient.Credentials = credentials;

                //smtpClient.Send(mailMsg);


                //var apiKey = _configuration.GetSection("SENDGRID_API_KEY").Value;
                var apiKey = "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";
                var client = new SendGridClient(apiKey);
                var emailFrom = new EmailAddress("tiago.peterson@gmail.com", "SCA");
                List<EmailAddress> tos = new List<EmailAddress>
                  {
                      new EmailAddress("tiago.peterson@gmail.com", "Peterson Andrade")
                  };

                var subject = "Email de Alerta: Evacuação";
                var htmlContent = @"<strong>"+ context.Message.Mensagem + "</strong>";
                var displayRecipients = false; // set this to true if you want recipients to see each others mail id 
                var msg = MailHelper.CreateSingleEmailToMultipleRecipients(emailFrom, tos, subject, "", htmlContent, false);
                client.SendEmailAsync(msg);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Task.CompletedTask;
        }
    }
}
