using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class AuthorizationToken
    {
        public string TokenId { get; set; }
        public string TokenType { get; set; }
        public string Value { get; set; }
        public DateTime IssuedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public List<string> Scopes { get; set; }
        public Dictionary<string, object> Claims { get; set; }
        public bool IsRevoked { get; set; }
        public string IssuedTo { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
    }
}
