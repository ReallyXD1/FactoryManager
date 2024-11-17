using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Production
{
    public class ProductionMetrics
    {
        public int Id { get; set; }
        public string LineId { get; set; }
        public DateTime Timestamp { get; set; }
        public int UnitsProduced { get; set; }
        public int DefectCount { get; set; }
        public double Efficiency { get; set; }
        public TimeSpan Downtime { get; set; }
        public Dictionary<string, double> KPIs { get; set; }
        public string ShiftId { get; set; }
        public Dictionary<string, object> QualityMetrics { get; set; }
    }
}
