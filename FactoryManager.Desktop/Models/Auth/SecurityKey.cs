using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityKey
    {
        public int Id { get; set; }
        public string KeyType { get; set; }
        public string Algorithm { get; set; }
        public string KeyValue { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsActive { get; set; }
        public string Purpose { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
        public int Version { get; set; }
    }
}
