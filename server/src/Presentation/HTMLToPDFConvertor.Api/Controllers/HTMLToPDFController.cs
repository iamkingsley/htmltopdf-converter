using MediatR;
using Microsoft.AspNetCore.Mvc;
using HTMLToPDFConvertor.Application.Features.HtmlToPdfConvertor.Commands.ConvertHtmlToPdf;

namespace HTMLToPDFConvertor.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HTMLToPDFController(ISender sender) : ControllerBase
    {
        [HttpPost("GeneratePdf", Name = "GeneratePdf")]
        public async Task<IActionResult> GeneratePdf([FromForm] IFormFile file)
        {
            try
            {
                // Convert to PDF and return byte array
                var pdfBytes = await sender.Send(new ConvertHtmlToPdfCommand(file));

                // Return the PDF file as a response
                return File(pdfBytes, "application/pdf", "GeneratedDocument.pdf");
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

    }

}
