using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityVisitor
    {
        public int Id { get; set; }
        public string VisitorType { get; set; }
        public List<string> VisitableElements { get; set; }
        public Dictionary<string, object> Operations { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public Dictionary<string, object> Context { get; set; }
        public int Priority { get; set; }
        public TimeSpan Timeout { get; set; }
    }
}
