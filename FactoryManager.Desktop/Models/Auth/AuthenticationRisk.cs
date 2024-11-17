using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class AuthenticationRisk
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string RiskType { get; set; }
        public int RiskLevel { get; set; }
        public Dictionary<string, object> RiskFactors { get; set; }
        public DateTime DetectedAt { get; set; }
        public string Status { get; set; }
        public List<string> TriggerEvents { get; set; }
        public Dictionary<string, object> Context { get; set; }
        public string Resolution { get; set; }
        public DateTime? ResolvedAt { get; set; }
    }
}
