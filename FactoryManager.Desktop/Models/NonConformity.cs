using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Quality
{
    public class NonConformity
    {
        public int Id { get; set; }
        public int ControlId { get; set; }
        public string Description { get; set; }
        public string Severity { get; set; }
        public DateTime ReportedDate { get; set; }
        public int ReportedById { get; set; }
        public string ReportedByName { get; set; }
        public string Status { get; set; }
        public string Resolution { get; set; }
        public DateTime? ResolvedDate { get; set; }
        public string Category { get; set; }
        public List<string> AffectedParameters { get; set; }
        public Dictionary<string, string> CorrectiveActions { get; set; }
        public bool RequiresFollowUp { get; set; }
    }
}
