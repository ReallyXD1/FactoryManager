using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models
{
    public class ReportSchedule
    {
        public int Id { get; set; }
        public int ReportTypeId { get; set; }
        public string Frequency { get; set; }
        public TimeSpan ExecutionTime { get; set; }
        public string[] Recipients { get; set; }
        public string ExportFormat { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastExecutionDate { get; set; }
        public DateTime NextExecutionDate { get; set; }
    }
}
