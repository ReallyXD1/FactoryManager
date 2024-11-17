using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityCredential
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public string Purpose { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsRevoked { get; set; }
        public string Owner { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
        public int Version { get; set; }
    }
}
