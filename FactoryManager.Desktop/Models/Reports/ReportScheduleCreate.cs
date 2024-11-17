using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Reports
{
    public class ReportScheduleCreate
    {
        public int ReportId { get; set; }
        public string Frequency { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string RecurrencePattern { get; set; }
        public List<string> Recipients { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        public string OutputFormat { get; set; }
        public bool SendEmpty { get; set; }
        public string TimeZone { get; set; }
        public Dictionary<string, string> DeliveryOptions { get; set; }
    }
}
