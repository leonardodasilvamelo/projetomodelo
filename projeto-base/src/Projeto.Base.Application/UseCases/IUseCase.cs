using Projeto.Base.Application.Commons.Interfaces;

namespace Projeto.Base.Application.UseCases;

public interface IUseCase<in TRequest, TResponse, TDomain>
	where TRequest : IBaseRequest<TDomain>
	where TResponse : IBaseResponse
{
	Task<TResponse> ExecutarAsync(TRequest request);

}