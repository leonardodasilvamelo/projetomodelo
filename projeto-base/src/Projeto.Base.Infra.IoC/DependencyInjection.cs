using Microsoft.Extensions.DependencyInjection;
using Projeto.Base.Infra.ExternalService.Interfaces;
using Projeto.Base.Infra.ExternalService.Services.Http;

namespace Projeto.Base.Infra.IoC;

public static class DependencyInjection
{
	public static IServiceCollection AddApplicationServices(this IServiceCollection services)
	{
		//Services		
		services.AddHttpClient<IHttpClientService, HttpClientService>();			

		return services;
	}
}
