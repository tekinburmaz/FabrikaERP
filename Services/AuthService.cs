using FabrikaERP.Data;
using FabrikaERP.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FabrikaERP.Services
{
    public class AuthService : IAuthService
    {
        private readonly FabrikaDbContext _context;

        public AuthService(FabrikaDbContext context)
        {
            _context = context;
        }

        public async Task<User?> LoginAsync(string username, string password)
        {
            // In a real application, DO NOT verify plain text passwords. Use hashing.
            // For the initial boilerplate, we are matching PasswordHash strictly.
            var user = await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Shift)
                .FirstOrDefaultAsync(u => u.Username == username && u.PasswordHash == password && u.IsActive);

            if (user != null)
            {
                SessionManager.Instance.SetCurrentUser(user);
            }

            return user;
        }

        public void Logout()
        {
            SessionManager.Instance.Logout();
        }
    }
}
