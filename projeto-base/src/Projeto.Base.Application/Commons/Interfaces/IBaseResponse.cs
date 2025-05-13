namespace Projeto.Base.Application.Commons.Interfaces;

public interface IBaseResponse
{
    bool Sucesso { get; set; }
    string Mensagem { get; set; }
}
