using System.Net;
using System.Net.Mail;

namespace Infrastructure.Notifications
{
    public class EmailConfiguration
    {
        public const string SmtpClient = "smtp.gmail.com";
        public const bool EnableSSL = true;
        public const int Port = 587;
        public const string UserName = "nikedev101@gmail.com";
        public const string Password = "ntjaxlsecjopcuwu";
        public const string FromAddress = "nikedev101@gmail.com";
    }
    public class EmailService
    {
        public string SendEmail(string to, string subject, string body, bool isHtml = true, string filename = "")
        {
            try
            {
                SmtpClient client = ConfigureSmtpClient();
                MailMessage message = ConfigureEmailSubjectAndFromAddress(subject);

                AddEmailAdddressToMail(to, message);

                AddEmailBody(body, isHtml, message);

                AddAttachementToEmail(filename, message);

                client.Send(message);

                return "success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private static SmtpClient ConfigureSmtpClient()
        {
            SmtpClient client = new SmtpClient(EmailConfiguration.SmtpClient, EmailConfiguration.Port);
            client.Credentials = new NetworkCredential(EmailConfiguration.UserName, EmailConfiguration.Password);
            client.EnableSsl = true;
            return client;
        }

        private static void AddEmailBody(string emailMessage, bool isHtml, MailMessage message)
        {
            message.Body = emailMessage;
            if (isHtml) message.IsBodyHtml = true;
        }

        private static void AddAttachementToEmail(string filename, MailMessage message)
        {
            if (!string.IsNullOrWhiteSpace(filename))
            {
                Attachment attachment = new Attachment(filename);
                message.Attachments.Add(attachment);
            }
        }

        private static MailMessage ConfigureEmailSubjectAndFromAddress(string subject)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(EmailConfiguration.FromAddress);
            message.Subject = subject;
            return message;
        }

        private  void AddEmailAdddressToMail(string toEmailAddress, MailMessage message)
        {
            if (toEmailAddress.Contains(';'))
            {
                foreach (var toEmail in toEmailAddress.Split(';'))
                {
                    message.To.Add(toEmail);
                }
            }
            else
            {
                message.To.Add(toEmailAddress);
            }
        }
    }

}
