using Microsoft.EntityFrameworkCore;
using NikePro.Data;
using NikePro.Interfaces;

namespace NikePro.Services
{
    public class ClientServices : IClientService
    {
        private readonly ApplicationDbContext _context;
        public ClientServices(ApplicationDbContext context) { _context = context; }

        public async Task<Client> GetClientByUserId(string userId)
        {
            return await _context.Clients.FirstOrDefaultAsync(x=>x.UserId == userId);
        }
    }
}
