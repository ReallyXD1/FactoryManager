using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Quality
{
    public class QualityStatistics
    {
        public double QualityRate { get; set; }
        public int TotalInspections { get; set; }
        public int PassedInspections { get; set; }
        public int FailedInspections { get; set; }
        public int OpenNonConformities { get; set; }
        public Dictionary<string, int> NonConformitiesByCategory { get; set; }
        public Dictionary<string, double> QualityByProduct { get; set; }
        public List<QualityTrend> QualityTrends { get; set; }
        public double AverageResolutionTime { get; set; }
        public Dictionary<string, int> DefectsByType { get; set; }
        public double FirstPassYield { get; set; }
        public Dictionary<string, double> ParameterCompliance { get; set; }
    }
}
