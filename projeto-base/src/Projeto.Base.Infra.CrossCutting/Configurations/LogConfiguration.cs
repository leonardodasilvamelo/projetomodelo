using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Projeto.Base.Infra.CrossCutting.Configurations
{
    public static class LogConfiguration
    {
        public static void ConfigurarLogs(this IServiceCollection services)
        {
            services.AddSingleton(Log.Logger);
        }
    }
}
