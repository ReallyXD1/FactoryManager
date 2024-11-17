using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityAction
    {
        public int Id { get; set; }
        public string ActionType { get; set; }
        public string Target { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        public List<string> RequiredPermissions { get; set; }
        public int RiskLevel { get; set; }
        public bool RequiresApproval { get; set; }
        public List<string> ApproverRoles { get; set; }
        public Dictionary<string, object> Validation { get; set; }
        public bool IsAudited { get; set; }
    }
}
