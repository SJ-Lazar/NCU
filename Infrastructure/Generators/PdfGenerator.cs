using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Infrastructure.Generators;

public class PdfGenerator
{
    public void GeneratePdf()
    {
        QuestPDF.Settings.License = LicenseType.Community;
        Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(20));

                page.Header()
                    .Text("NCU Star Stream")
                    .SemiBold().FontSize(36).FontColor(Colors.Red.Medium);

                page.Content()
                    .PaddingVertical(1, Unit.Millimetre)
                    .Column(x =>
                    {
                        x.Spacing(20);

                        x.Item().Text(@"Certainly, here's a descriptive text outlining the features and benefits of the system:
---
**Introducing NCUStarStream Portal: Revolutionizing Process Flow Management**
At NCU, we proudly present the NCUStarStream Portal, a cutting-edge process flow management system designed to elevate your organization's efficiency and streamline operations like never before.
**Seamless Navigation:** Experience a seamless journey through workflows akin to traversing the cosmic expanse. The portal's intuitive interface guides users effortlessly, offering a clear and structured pathway through intricate processes.
**Galactic Connectivity:** Connect disparate elements of your operations across vast distances effortlessly. The NCUStarStream Portal acts as a cosmic network, linking departments, tasks, and resources with unparalleled ease and speed.
**Astro-Optimized Efficiency:** Harness the power of astro-optimized algorithms, ensuring processes are streamlined to perfection. This system is tailored to boost productivity, minimize bottlenecks, and maximize output efficiency.
**Universal Accessibility:** Access your workflows from anywhere in the universe! Our portal is designed to be universally accessible, ensuring teams can collaborate seamlessly regardless of their location.
**Cosmic Insights:** Gain unparalleled insights into your processes with our advanced analytics. Dive deep into the cosmic data streams to uncover patterns, trends, and opportunities for further optimization.
**Secure Constellation:** Rest easy knowing your data is safeguarded within our secure cosmic constellation. The NCUStarStream Portal employs state-of-the-art security protocols, ensuring the integrity and confidentiality of your valuable information.
Embark on a new frontier of efficiency and connectivity with the NCUStarStream Portal. Join us in reshaping the way you manage processes, transcending boundaries and reaching for the stars in operational excellence.
---
This text aims to convey the innovative and futuristic capabilities of the NCUStarStream Portal while incorporating the space-themed elements we discussed earlier.").FontSize(8);
                        x.Item().Image(@"C:\Temp\logo.jpg");
                    });

                page.Footer()
                    .AlignCenter()
                    .Text(x =>
                    {
                        x.Span("Page ");
                        x.CurrentPageNumber();
                    });
            });
        })
        .GeneratePdf(@"C:\Temp\hello.pdf");
    }
}
