using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class AuthenticationSession
    {
        public string SessionId { get; set; }
        public int UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime LastActivity { get; set; }
        public string AuthMethod { get; set; }
        public Dictionary<string, object> SessionData { get; set; }
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }
        public bool IsActive { get; set; }
        public List<string> Permissions { get; set; }
    }
}
