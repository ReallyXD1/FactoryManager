using System;

namespace FactoryManager.Desktop.Models.Auth
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime TokenExpiration { get; set; }
        public User User { get; set; }
        public List<string> Permissions { get; set; }
        public Dictionary<string, object> Settings { get; set; }
        public string SessionId { get; set; }
    }
}
