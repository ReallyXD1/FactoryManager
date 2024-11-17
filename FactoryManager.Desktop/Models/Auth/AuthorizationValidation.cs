using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class AuthorizationValidation
    {
        public string ValidationId { get; set; }
        public string RequestId { get; set; }
        public List<string> ValidatedPolicies { get; set; }
        public Dictionary<string, bool> Results { get; set; }
        public DateTime ValidatedAt { get; set; }
        public string ValidatedBy { get; set; }
        public TimeSpan ProcessingTime { get; set; }
        public Dictionary<string, object> Context { get; set; }
        public List<string> Violations { get; set; }
        public bool IsValid { get; set; }
    }
}
