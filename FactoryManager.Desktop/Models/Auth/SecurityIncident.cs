using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityIncident
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public DateTime ReportedAt { get; set; }
        public string ReportedBy { get; set; }
        public string Status { get; set; }
        public List<string> AssignedTo { get; set; }
        public Dictionary<string, object> Evidence { get; set; }
        public DateTime? ResolvedAt { get; set; }
    }
}
