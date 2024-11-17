using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Production
{
    public class ProductionMaintenance
    {
        public int Id { get; set; }
        public string LineId { get; set; }
        public string Type { get; set; }
        public DateTime ScheduledDate { get; set; }
        public TimeSpan EstimatedDuration { get; set; }
        public string Technician { get; set; }
        public List<string> Tasks { get; set; }
        public string Status { get; set; }
        public Dictionary<string, object> Parts { get; set; }
        public string Priority { get; set; }
    }
}
