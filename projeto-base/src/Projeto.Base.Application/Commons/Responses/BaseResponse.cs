using System.Net;
using Projeto.Base.Application.Commons.Interfaces;

namespace Projeto.Base.Application.Commons.Responses;

public class BaseResponse<T> : IBaseResponse
{
    public bool Sucesso { get; set; }
    public string Mensagem { get; set; }
    public T Data { get; set; }
    public List<string> Errors { get; set; }
    public HttpStatusCode StatusCode { get; set; }

    public static BaseResponse<T> Ok(T data, string mensagem = "Operação realizada com sucesso")
    {
        return new BaseResponse<T>
        {
            Sucesso = true,
            Mensagem = mensagem,
            Data = data,
            StatusCode = HttpStatusCode.OK
        };
    }

    public static BaseResponse<T> Fail(string mensagem, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    {
        return new BaseResponse<T>
        {
            Sucesso = false,
            Mensagem = mensagem,
            StatusCode = statusCode,
            Errors = new List<string> { mensagem }
        };
    }

    public static BaseResponse<T> Fail(List<string> errors, string mensagem = "Operação falhou", HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    {
        return new BaseResponse<T>
        {
            Sucesso = false,
            Mensagem = mensagem,
            StatusCode = statusCode,
            Errors = errors
        };
    }

    public static BaseResponse<T> NotFound(string mensagem = "Recurso não encontrado")
    {
        return new BaseResponse<T>
        {
            Sucesso = false,
            Mensagem = mensagem,
            StatusCode = HttpStatusCode.NotFound,
            Errors = new List<string> { mensagem }
        };
    }

    public static BaseResponse<T> Unauthorized(string mensagem = "Não autorizado")
    {
        return new BaseResponse<T>
        {
            Sucesso = false,
            Mensagem = mensagem,
            StatusCode = HttpStatusCode.Unauthorized,
            Errors = new List<string> { mensagem }
        };
    }

    public static BaseResponse<T> Forbidden(string mensagem = "Acesso negado")
    {
        return new BaseResponse<T>
        {
            Sucesso = false,
            Mensagem = mensagem,
            StatusCode = HttpStatusCode.Forbidden,
            Errors = new List<string> { mensagem }
        };
    }

    public static BaseResponse<T> InternalServerError(string mensagem = "Erro interno no servidor")
    {
        return new BaseResponse<T>
        {
            Sucesso = false,
            Mensagem = mensagem,
            StatusCode = HttpStatusCode.InternalServerError,
            Errors = new List<string> { mensagem }
        };
    }
}
