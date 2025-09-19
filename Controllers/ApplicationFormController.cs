using Microsoft.AspNetCore.Mvc;
using PdfGenTest.Documents;
using PdfGenTest.Models;
using QuestPDF.Fluent;

namespace PdfGenTest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApplicationFormController : ControllerBase
{
    [HttpGet("pdf")]
    public IActionResult GetPdf()
    {
        var data = ApplicationFormData.CreateDefault();
        var document = new ApplicationFormDocument(data);
        var pdfContent = document.GeneratePdf();

        return File(pdfContent, "application/pdf", "ApplicationForm.pdf");
    }
}
