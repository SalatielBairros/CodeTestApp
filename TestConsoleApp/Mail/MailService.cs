using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace CodeTestApp.Mail
{
    public class MailService
    {
        public static void SendTestEmail()
        {
            try
            {
                Console.WriteLine("Enviando email...");
                TestEmail();
                Console.WriteLine("Email Enviado");

            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("Erro ao enviar email: ");
                Console.WriteLine();
                Console.WriteLine(ex);
            }
            Console.ReadKey();
        }

        private static void TestEmail()
        {
            MailAddress maddrto = new MailAddress("salatiel@softmovel.com.br", "Salatiel C. Bairros", Encoding.GetEncoding("ISO-8859-1"));
            MailAddress maddrfrom = new MailAddress("nfemobile-dev@electrolux.com.br", "Electrolux", Encoding.GetEncoding("ISO-8859-1"));
            MailMessage mail = new MailMessage(maddrfrom, maddrto)
            {
                Body = "Teste de envio de Email",
                Subject = "TESTE DE EMAIL",
                IsBodyHtml = false
            };
            //if (!string.IsNullOrWhiteSpace(data.EmailReply) && !string.IsNullOrWhiteSpace(data.NameReply))
            //{
            //    mail.CC.Add(new MailAddress(data.EmailReply, data.NameReply, Encoding.GetEncoding("ISO-8859-1")));
            //}

            //SmtpClient smtp = new SmtpClient("mail.electrolux.com.br", 25)
            //{
            //    Credentials = new NetworkCredential(),
            //    EnableSsl = false
            //};
            Console.WriteLine("Email enviado.");

            try
            {
                using (SmtpClient smtp = new SmtpClient("mail.electrolux.com.br", 25))
                {
                    smtp.Credentials = new NetworkCredential();
                    
                    smtp.Send(mail);
                    smtp.Dispose();
                }
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
