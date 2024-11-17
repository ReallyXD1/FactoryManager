using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityClaim
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public string Issuer { get; set; }
        public string Subject { get; set; }
        public DateTime IssuedAt { get; set; }
        public bool IsVerified { get; set; }
        public List<string> Evidence { get; set; }
        public Dictionary<string, object> Properties { get; set; }
        public int Priority { get; set; }
    }
}
