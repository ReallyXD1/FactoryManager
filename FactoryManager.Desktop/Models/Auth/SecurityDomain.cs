using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityDomain
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> TrustedDomains { get; set; }
        public Dictionary<string, object> Policies { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<string> AuthorizedUsers { get; set; }
        public Dictionary<string, object> Configuration { get; set; }
        public int TrustLevel { get; set; }
    }
}
