using FabrikaERP.Models;
using System.Threading.Tasks;

namespace FabrikaERP.Services
{
    public interface IAuthService
    {
        Task<User?> LoginAsync(string username, string password);
        void Logout();
    }
}
