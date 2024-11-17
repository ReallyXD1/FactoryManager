using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityCertificate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string SerialNumber { get; set; }
        public DateTime IssuedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public string Issuer { get; set; }
        public string Subject { get; set; }
        public bool IsRevoked { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
    }
}
