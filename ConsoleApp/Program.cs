

using Infrastructure.Generators;
using Infrastructure.Notifications;

PdfGenerator pdfGenerator = new PdfGenerator();
pdfGenerator.GeneratePdf();

EmailService emailService = new EmailService();
var response = emailService.SendEmail("lazarsalman@gmail.com", "subject", "body", true, "");

if (response.Contains("success"))
{
    Console.WriteLine("Email Sent Sucessfully");
}
else
{
    Console.WriteLine(response);
}