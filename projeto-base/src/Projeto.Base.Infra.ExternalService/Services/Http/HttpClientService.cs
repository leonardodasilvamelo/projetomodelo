using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Projeto.Base.Infra.ExternalService.Interfaces;

namespace Projeto.Base.Infra.ExternalService.Services.Http;

public class HttpClientService : IHttpClientService
{
	private readonly HttpClient _httpClient;

	public HttpClientService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task<HttpResponseMessage> EnviarAsync(string uri, HttpMethod metodoHttp, Dictionary<string, string> cabecalhos = null, object dadosDaRequisicao = null)
	{
		using var request = new HttpRequestMessage(metodoHttp, uri);

		if (cabecalhos != null)
			foreach (var item in cabecalhos)
				request.Headers.Add(item.Key, item.Value);

		ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

		if (dadosDaRequisicao != null)
			using (request.Content = new StringContent(JsonConvert.SerializeObject(dadosDaRequisicao), Encoding.UTF8, "application/json"))
				return await _httpClient.SendAsync(request);

		return await _httpClient.SendAsync(request);
	}

	public async Task<HttpResponseMessage> EnviarComAutenticacaoAsync(string uri, HttpMethod metodoHttp, string username, string password, Dictionary<string, string> cabecalhos = null, object dadosDaRequisicao = null)
	{
		using var request = new HttpRequestMessage(metodoHttp, uri);

		if (cabecalhos != null)
			foreach (var item in cabecalhos)
				request.Headers.Add(item.Key, item.Value);

		string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));

		_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

		ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

		if (dadosDaRequisicao != null)
			using (request.Content = new StringContent(JsonConvert.SerializeObject(dadosDaRequisicao), Encoding.UTF8, "application/json"))
				return await _httpClient.SendAsync(request);

		return await _httpClient.SendAsync(request);
	}
}
