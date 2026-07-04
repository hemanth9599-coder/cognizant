using System.Net;
using System.Net.Mail;

namespace CustomerCommLib
{
    // Interface
    public interface IMailSender
    {
        bool SendMail(string toAddress, string message);
    }

    // Mail Sender Implementation
    public class MailSender : IMailSender
    {
        public bool SendMail(string toAddress, string message)
        {
            // SMTP Code (Disabled for Unit Testing)

            /*
            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("your_email@gmail.com");
            mail.To.Add(toAddress);
            mail.Subject = "Test Mail";
            mail.Body = message;

            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("username", "password");
            smtp.EnableSsl = true;

            smtp.Send(mail);
            */

            return true;
        }
    }

    // Class Under Test
    public class CustomerCommunication
    {
        private readonly IMailSender _mailSender;

        public CustomerCommunication(IMailSender mailSender)
        {
            _mailSender = mailSender;
        }

        public bool SendMailToCustomer()
        {
            _mailSender.SendMail(
                "cust123@abc.com",
                "Some Message");

            return true;
        }
    }
}