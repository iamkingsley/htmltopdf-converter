
using System.Text;
using HTMLToPDFConvertor.Application.Interfaces;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.AspNetCore.Http;
using iTextSharp.tool.xml;

namespace HTMLToPDFConvertor.Convertor.Services;

public class Convertor : IConvertor
{
    public async Task<byte[]> ConvertHtmlToPdf(IFormFile file)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        
        using MemoryStream memoryStream = new MemoryStream();
        // Extract html content from file
        using var reader = new StreamReader(file.OpenReadStream());
        var htmlContent = await reader.ReadToEndAsync();

        // Create PDF in memory stream
        Document pdfDoc = new Document(PageSize.A4);
        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
        pdfDoc.Open();
        using (StringReader sr = new StringReader(htmlContent))
        {
            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
        }
        pdfDoc.Close();

        // Return the byte array
        return memoryStream.ToArray();
    }
}