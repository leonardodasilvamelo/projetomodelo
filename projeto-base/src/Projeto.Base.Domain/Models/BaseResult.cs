using System.Text.Json.Serialization;

namespace Projeto.Base.Domain.Models;

public class BaseResult
{
	[JsonIgnore]
	public int StatusCode { get; set; }

	public string Mensagem { get; set; }
}
