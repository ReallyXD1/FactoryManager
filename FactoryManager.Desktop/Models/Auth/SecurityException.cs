using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityException
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Reason { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public Dictionary<string, object> Conditions { get; set; }
        public List<string> AffectedPolicies { get; set; }
        public string Status { get; set; }
        public Dictionary<string, object> Justification { get; set; }
    }
}