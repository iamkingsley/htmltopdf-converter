using Microsoft.AspNetCore.Http;

namespace HTMLToPDFConvertor.Application.Interfaces;

public interface IConvertor
{
    Task<byte[]> ConvertHtmlToPdf(IFormFile file);
}