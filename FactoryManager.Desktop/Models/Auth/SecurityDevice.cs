using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityDevice
    {
        public int Id { get; set; }
        public string DeviceId { get; set; }
        public int UserId { get; set; }
        public string DeviceType { get; set; }
        public string Name { get; set; }
        public DateTime RegisteredAt { get; set; }
        public DateTime LastUsed { get; set; }
        public bool IsTrusted { get; set; }
        public Dictionary<string, object> Capabilities { get; set; }
        public List<string> AuthenticationMethods { get; set; }
    }
}
