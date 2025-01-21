
using HTMLToPDFConvertor.Application.Interfaces;
using MediatR;

namespace HTMLToPDFConvertor.Application.Features.HtmlToPdfConvertor.Commands.ConvertHtmlToPdf;

public class ConvertHtmlToPdfCommandHandler(
    IConvertor convertor)
    : IRequestHandler<ConvertHtmlToPdfCommand, byte[]>
{
    public async Task<byte[]> Handle(ConvertHtmlToPdfCommand command, CancellationToken cancellationToken)
    {
        if (command.file == null || command.file.Length == 0)
        {
            throw new ArgumentException("file is empty");
        }

        if (command.file.ContentType != "text/html"
            && command.file.ContentType != "application/xhtml+xml")
        {
            throw new ArgumentException("The file is not a valid HTML file");
        }

        return await convertor.ConvertHtmlToPdf(command.file);
    }
}
