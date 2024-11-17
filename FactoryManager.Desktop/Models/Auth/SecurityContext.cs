using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityContext
    {
        public string ContextId { get; set; }
        public int UserId { get; set; }
        public string Environment { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        public List<string> ActivePolicies { get; set; }
        public Dictionary<string, string> Variables { get; set; }
        public DateTime CreatedAt { get; set; }
        public string SessionId { get; set; }
        public List<string> AppliedRules { get; set; }
        public int TrustLevel { get; set; }
    }
}
