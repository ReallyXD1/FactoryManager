using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class AuthorizationDecision
    {
        public string DecisionId { get; set; }
        public string RequestId { get; set; }
        public bool IsAllowed { get; set; }
        public DateTime Timestamp { get; set; }
        public List<string> AppliedPolicies { get; set; }
        public Dictionary<string, object> Reasons { get; set; }
        public string DecisionMaker { get; set; }
        public TimeSpan ProcessingTime { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
        public List<string> Obligations { get; set; }
    }
}
