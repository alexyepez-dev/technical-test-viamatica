using Microsoft.Extensions.DependencyInjection;
using VMT.TechnicalTest.Application.Contracts.CSV;
using VMT.TechnicalTest.Application.Providers.Manager.CSV;

namespace VMT.TechnicalTest.Application.Extension
{
    public static class ExtensionProvider
    {
        public static IServiceCollection AddApplicationProvider(this IServiceCollection services)
        {
            services.AddScoped<IExportCSVProvider, ExportCSVProvider>();

            return services;
        }
    }
}