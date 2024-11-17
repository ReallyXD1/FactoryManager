using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Reports
{
    public class Report
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime GeneratedDate { get; set; }
        public int GeneratedById { get; set; }
        public string GeneratedByName { get; set; }
        public string Status { get; set; }
        public string Format { get; set; }
        public long FileSize { get; set; }
        public string FilePath { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        public List<string> Tags { get; set; }
        public bool IsScheduled { get; set; }
        public DateTime? NextScheduledRun { get; set; }
        public List<ReportDistribution> Distributions { get; set; }
    }
}
