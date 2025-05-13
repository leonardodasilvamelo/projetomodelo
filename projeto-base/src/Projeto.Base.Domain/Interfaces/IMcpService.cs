using System.Threading.Tasks;

namespace Transacao.Cartao.GatewayAcl.Domain.Interfaces
{
    public interface IMcpService
    {
        Task<bool> ExecutarMyFirstMcpAsync();
    }
} 