using FabrikaERP.Models;
using System;

namespace FabrikaERP.Services
{
    public sealed class SessionManager
    {
        private static readonly Lazy<SessionManager> lazy = new Lazy<SessionManager>(() => new SessionManager());

        public static SessionManager Instance { get { return lazy.Value; } }

        private SessionManager() { }

        public User? CurrentUser { get; private set; }

        public bool IsLoggedIn => CurrentUser != null;

        public void SetCurrentUser(User user)
        {
            CurrentUser = user;
        }

        public void Logout()
        {
            CurrentUser = null;
        }
    }
}
