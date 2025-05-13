namespace Projeto.Base.Application.Commons.Interfaces
{
    public interface IBaseRequest<TDomain>
    {
        TDomain ToDomain();
        void FromDomain(TDomain domain);
    }
}
