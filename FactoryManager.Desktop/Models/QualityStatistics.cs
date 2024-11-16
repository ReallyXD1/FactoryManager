using System.Collections.Generic;

namespace FactoryManager.Desktop.Models
{
    public class QualityStatistics
    {
        public double QualityRate { get; set; }
        public double Trend { get; set; }
        public int TotalInspections { get; set; }
        public int FailedInspections { get; set; }
        public int OpenNonConformities { get; set; }
        public List<ChartDataPoint> QualityTrends { get; set; }
    }
}
