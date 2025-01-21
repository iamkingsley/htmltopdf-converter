using HTMLToPDFConvertor.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HTMLToPDFConvertor.Convertor;

public static class ConvertorServices
{
    public static IServiceCollection AddConvertorServices(this IServiceCollection services)
    {
        services.AddScoped<IConvertor, Services.Convertor>();
        return services;
    }
}