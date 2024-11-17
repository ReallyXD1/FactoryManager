using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecuritySession
    {
        public string SessionId { get; set; }
        public int UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime LastActivity { get; set; }
        public string SecurityLevel { get; set; }
        public Dictionary<string, object> SessionAttributes { get; set; }
        public List<string> ActivePermissions { get; set; }
        public string ClientInfo { get; set; }
        public Dictionary<string, object> SecurityContext { get; set; }
        public List<string> AuthenticationFactors { get; set; }
    }
}
