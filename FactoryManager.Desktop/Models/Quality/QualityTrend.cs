using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Quality
{
    public class QualityTrend
    {
        public DateTime Date { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public double QualityScore { get; set; }
        public int DefectCount { get; set; }
        public Dictionary<string, int> DefectsByType { get; set; }
        public double YieldRate { get; set; }
        public int InspectionCount { get; set; }
        public Dictionary<string, double> ParameterValues { get; set; }
        public double ComplianceRate { get; set; }
        public List<string> ImprovementActions { get; set; }
    }
}
