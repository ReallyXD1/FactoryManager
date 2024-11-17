using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityCredential
    {
        public int Id { get; set; }
        public string CredentialType { get; set; }
        public string Identifier { get; set; }
        public string SecretHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public int UserId { get; set; }
        public bool IsRevoked { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
        public List<string> AllowedOperations { get; set; }
    }
}
