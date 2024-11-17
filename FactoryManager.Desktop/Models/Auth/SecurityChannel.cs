using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityChannel
    {
        public int Id { get; set; }
        public string ChannelType { get; set; }
        public string Protocol { get; set; }
        public Dictionary<string, object> Settings { get; set; }
        public bool IsEncrypted { get; set; }
        public string Status { get; set; }
        public DateTime LastActive { get; set; }
        public List<string> AllowedOperations { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
        public int Timeout { get; set; }
    }
}
