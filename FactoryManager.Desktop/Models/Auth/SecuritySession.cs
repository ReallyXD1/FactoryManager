using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecuritySession
    {
        public int Id { get; set; }
        public string SessionId { get; set; }
        public int UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime LastActivity { get; set; }
        public string IpAddress { get; set; }
        public Dictionary<string, object> Context { get; set; }
        public bool IsActive { get; set; }
        public List<string> Permissions { get; set; }
        public Dictionary<string, object> State { get; set; }
    }
}
