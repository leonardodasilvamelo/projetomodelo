using Azure.Monitor.OpenTelemetry.AspNetCore;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Projeto.Base.Infra.CrossCutting.Configurations
{
    public static class TelemetriaConfiguration
    {
        public static void ConfigurarTelemetria(this IServiceCollection services, IConfiguration configuracao)
        {
            var configuracaoDaTelemetria = services.BuildServiceProvider().GetService<TelemetryConfiguration>();

            if (configuracaoDaTelemetria == null)
            {
                configuracaoDaTelemetria = new TelemetryConfiguration();
                configuracao.Bind("ApplicationInsights", configuracaoDaTelemetria);
                configuracaoDaTelemetria.ConnectionString = configuracao.GetConnectionString("ApplicationInsights");
            }

            services.AddSingleton(configuracaoDaTelemetria);
            services.AddSingleton(sp => new TelemetryClient(configuracaoDaTelemetria));


            services.AddOpenTelemetry().UseAzureMonitor(monitor => monitor.ConnectionString = configuracao.GetConnectionString("ApplicationInsights"));

            var resourceAttributes = new Dictionary<string, object> {
                { "service.name", "Aks-Projeto.Base" }
            };

            services.ConfigureOpenTelemetryTracerProvider((sp, builder) => builder.ConfigureResource(resourceBuilder => resourceBuilder.AddService("service-name")));

            services.ConfigureOpenTelemetryTracerProvider((sp, builder) =>
                builder.ConfigureResource(resourceBuilder =>
                resourceBuilder.AddAttributes(resourceAttributes)));
        }
    }
}
