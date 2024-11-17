using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Production
{
    public class ProductionEfficiency
    {
        public int Id { get; set; }
        public string LineId { get; set; }
        public DateTime MeasuredAt { get; set; }
        public double OEE { get; set; }
        public double Availability { get; set; }
        public double Performance { get; set; }
        public double Quality { get; set; }
        public Dictionary<string, double> Metrics { get; set; }
        public string ShiftId { get; set; }
        public TimeSpan RunTime { get; set; }
    }
}
