using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class AuthorizationCache
    {
        public string CacheKey { get; set; }
        public int UserId { get; set; }
        public List<string> Permissions { get; set; }
        public List<string> Roles { get; set; }
        public Dictionary<string, object> DecisionCache { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public string Version { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
        public bool IsValid { get; set; }
    }
}
