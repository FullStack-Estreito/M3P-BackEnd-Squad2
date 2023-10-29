
// using System.Net.Mail;

// namespace Backend.Service;

// public class Email
// {



//     protected void sendMessage_Click(object sender, EventArgs e)
//     {
//         var senderName = "teste";
//         System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
//         client.Host = "smtp.gmail.com";
//         client.EnableSsl = true;
//         client.Credentials = new System.Net.NetworkCredential("seu email", "sua senha");
//         MailMessage mail = new MailMessage();
//         mail.Sender = new System.Net.Mail.MailAddress("email que vai enviar", "ENVIADOR");
//         mail.From = new MailAddress("de quem", "ENVIADOR");
//         mail.To.Add(new MailAddress("paraquem", "RECEBEDOR"));
//         mail.Subject = "Contato";
//         mail.Body = " Mensagem do site:<br/> Nome:  " + senderName.Text + "<br/> Email : " + senderEmail.Text + 
//         " <br/> Mensagem : " + message.Text;
//         mail.IsBodyHtml = true;
//         mail.Priority = MailPriority.High;
//         try
//         {
//             client.Send(mail);
//         }
//         catch (System.Exception erro)
//         {
//             //trata erro
//         }
//         finally
//         {
//             mail = null;
//         }

//     }
// }