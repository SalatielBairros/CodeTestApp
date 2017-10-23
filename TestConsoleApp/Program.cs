using System;
using CodeTestApp.Mail;

namespace CodeTestApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MailService.SendTestEmail();
            Console.ReadKey();
        }
    }
}
