using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityQuota
    {
        public int Id { get; set; }
        public string ResourceType { get; set; }
        public int Limit { get; set; }
        public int Used { get; set; }
        public string Period { get; set; }
        public DateTime ResetAt { get; set; }
        public bool IsEnforced { get; set; }
        public List<string> AppliesTo { get; set; }
        public Dictionary<string, object> Thresholds { get; set; }
        public string Action { get; set; }
    }
}
