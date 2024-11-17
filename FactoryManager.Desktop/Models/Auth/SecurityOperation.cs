using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityOperation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        public bool RequiresApproval { get; set; }
        public int RiskLevel { get; set; }
        public List<string> RequiredRoles { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public string Status { get; set; }
    }
}
