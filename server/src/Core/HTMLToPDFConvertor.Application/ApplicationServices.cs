using HTMLToPDFConvertor.Application.Features.HtmlToPdfConvertor.Commands.ConvertHtmlToPdf;
using Microsoft.Extensions.DependencyInjection;


namespace HTMLToPDFConvertor.Application;

public static class ApplicationSetup
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(req =>
        {
            req.RegisterServicesFromAssemblyContaining<ConvertHtmlToPdfCommandHandler>();
        });
        return services;
    }
}
