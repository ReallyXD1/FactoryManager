using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityToken
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public DateTime IssuedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public string IssuedTo { get; set; }
        public bool IsRevoked { get; set; }
        public List<string> Scopes { get; set; }
        public Dictionary<string, object> Claims { get; set; }
        public string Purpose { get; set; }
    }
}
