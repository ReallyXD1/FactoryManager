using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityAuthorization
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Resource { get; set; }
        public List<string> Permissions { get; set; }
        public DateTime GrantedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public string GrantedBy { get; set; }
        public bool IsActive { get; set; }
        public Dictionary<string, object> Conditions { get; set; }
        public string Scope { get; set; }
    }
}