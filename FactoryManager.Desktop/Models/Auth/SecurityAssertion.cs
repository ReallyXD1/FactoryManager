using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityAssertion
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Issuer { get; set; }
        public string Subject { get; set; }
        public DateTime IssuedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public Dictionary<string, object> Claims { get; set; }
        public string Signature { get; set; }
        public bool IsValid { get; set; }
        public List<string> Conditions { get; set; }
    }
}
