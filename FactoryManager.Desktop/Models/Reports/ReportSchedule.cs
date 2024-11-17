using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Reports
{
    public class ReportSchedule
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        public string Frequency { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string RecurrencePattern { get; set; }
        public List<string> Recipients { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastRun { get; set; }
        public DateTime NextRun { get; set; }
        public string OutputFormat { get; set; }
    }
}
