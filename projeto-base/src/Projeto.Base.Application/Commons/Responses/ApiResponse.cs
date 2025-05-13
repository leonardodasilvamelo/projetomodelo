using System.Net;

namespace Projeto.Base.Application.Commons.Responses;

public class ApiResponse<T>
{
	public bool Success { get; set; }
	public string Message { get; set; }
	public T Data { get; set; }
	public List<string> Errors { get; set; }
	public HttpStatusCode StatusCode { get; set; }

	public static ApiResponse<T> Ok(T data, string message = "Operação realizada com sucesso")
	{
		return new ApiResponse<T>
		{
			Success = true,
			Message = message,
			Data = data,
			StatusCode = HttpStatusCode.OK
		};
	}

	public static ApiResponse<T> Fail(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
	{
		return new ApiResponse<T>
		{
			Success = false,
			Message = message,
			StatusCode = statusCode,
			Errors = new List<string> { message }
		};
	}

	public static ApiResponse<T> Fail(List<string> errors, string message = "Operação falhou", HttpStatusCode statusCode = HttpStatusCode.BadRequest)
	{
		return new ApiResponse<T>
		{
			Success = false,
			Message = message,
			StatusCode = statusCode,
			Errors = errors
		};
	}

	public static ApiResponse<T> NotFound(string message = "Recurso não encontrado")
	{
		return new ApiResponse<T>
		{
			Success = false,
			Message = message,
			StatusCode = HttpStatusCode.NotFound,
			Errors = new List<string> { message }
		};
	}

	public static ApiResponse<T> Unauthorized(string message = "Não autorizado")
	{
		return new ApiResponse<T>
		{
			Success = false,
			Message = message,
			StatusCode = HttpStatusCode.Unauthorized,
			Errors = new List<string> { message }
		};
	}

	public static ApiResponse<T> Forbidden(string message = "Acesso negado")
	{
		return new ApiResponse<T>
		{
			Success = false,
			Message = message,
			StatusCode = HttpStatusCode.Forbidden,
			Errors = new List<string> { message }
		};
	}

	public static ApiResponse<T> InternalServerError(string message = "Erro interno no servidor")
	{
		return new ApiResponse<T>
		{
			Success = false,
			Message = message,
			StatusCode = HttpStatusCode.InternalServerError,
			Errors = new List<string> { message }
		};
	}
}
