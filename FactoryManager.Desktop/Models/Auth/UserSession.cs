using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class UserSession
    {
        public string SessionId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public string IpAddress { get; set; }
        public string DeviceId { get; set; }
        public string DeviceType { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastActivityAt { get; set; }
        public Dictionary<string, string> ClientInfo { get; set; }
        public string Location { get; set; }
    }
}
