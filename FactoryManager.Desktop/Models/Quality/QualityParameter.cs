using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Quality
{
    public class QualityParameter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public double TargetValue { get; set; }
        public double ActualValue { get; set; }
        public bool IsCritical { get; set; }
        public string MeasurementMethod { get; set; }
        public string Category { get; set; }
        public List<string> ApplicableProducts { get; set; }
        public Dictionary<string, string> Specifications { get; set; }
        public string ToleranceRange { get; set; }
    }
}
