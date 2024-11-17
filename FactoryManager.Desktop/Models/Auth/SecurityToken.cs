using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityToken
    {
        public string TokenId { get; set; }
        public string TokenType { get; set; }
        public string Value { get; set; }
        public DateTime IssuedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public int IssuedTo { get; set; }
        public string Purpose { get; set; }
        public Dictionary<string, string> Claims { get; set; }
        public bool IsRevoked { get; set; }
        public List<string> Scopes { get; set; }
    }
}
