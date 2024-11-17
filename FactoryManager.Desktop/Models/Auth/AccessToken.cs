using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class AccessToken
    {
        public string Token { get; set; }
        public string Type { get; set; }
        public DateTime IssuedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public string RefreshToken { get; set; }
        public List<string> Scopes { get; set; }
        public Dictionary<string, string> Claims { get; set; }
        public string DeviceId { get; set; }
        public string IpAddress { get; set; }
        public bool IsRevoked { get; set; }
        public string RevokedReason { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
    }
}
