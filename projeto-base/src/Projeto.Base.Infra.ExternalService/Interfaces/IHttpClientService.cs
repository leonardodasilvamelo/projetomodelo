namespace Projeto.Base.Infra.ExternalService.Interfaces;

public interface IHttpClientService
{
	Task<HttpResponseMessage> EnviarAsync(string uri, HttpMethod metodoHttp, Dictionary<string, string> cabecalhos = null, object dadosDaRequisicao = null);

	Task<HttpResponseMessage> EnviarComAutenticacaoAsync(string uri, HttpMethod metodoHttp, string username, string password, Dictionary<string, string> cabecalhos = null, object dadosDaRequisicao = null);
}
