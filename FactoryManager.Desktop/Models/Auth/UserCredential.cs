using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class UserCredential
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CredentialType { get; set; }
        public string Identifier { get; set; }
        public string Secret { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public bool IsActive { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
        public string Status { get; set; }
        public DateTime LastUsed { get; set; }
    }
}
