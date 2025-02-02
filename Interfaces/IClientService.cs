using NikePro.Data;

namespace NikePro.Interfaces
{
    public interface IClientService
    {
        Task<Client> GetClientByUserId(string userId);
    }
}
