using MediatR;
using Microsoft.AspNetCore.Http;

namespace HTMLToPDFConvertor.Application.Features.HtmlToPdfConvertor.Commands.ConvertHtmlToPdf;

public record ConvertHtmlToPdfCommand(IFormFile file) : IRequest<byte[]>;