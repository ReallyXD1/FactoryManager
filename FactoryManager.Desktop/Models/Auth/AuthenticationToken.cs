using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class AuthenticationToken
    {
        public string TokenId { get; set; }
        public int UserId { get; set; }
        public string Purpose { get; set; }
        public string Value { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsUsed { get; set; }
        public string DeviceId { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
        public List<string> Scopes { get; set; }
    }
}
