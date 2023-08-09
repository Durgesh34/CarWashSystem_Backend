using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace CarWashSystem.Controllers
{
  public class EmailController : ControllerBase
  {
   /*

      [HttpPost]
      public IActionResult SendEmail(EmailDTO emailDTO)
      {


        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse("pharamacare@gmail.com"));
        email.To.Add(MailboxAddress.Parse(emailDTO.email));

        email.Subject = emailDTO.subject;
        email.Body = new TextPart(MimeKit.Text.TextFormat.Plain) { Text = emailDTO.body };
        using var smtp = new SmtpClient();
        smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
        smtp.Authenticate("pharamacare@gmail.com", "ykocyltjuhioyunl");

        smtp.Send(email);
        smtp.Disconnect(true);
        return Ok();
      }
   */
    }
  }
  
