using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Quality
{
    public class QualityTrendFilter
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<string> ProductIds { get; set; }
        public List<string> Parameters { get; set; }
        public string TrendType { get; set; }
        public string GroupBy { get; set; }
        public int Resolution { get; set; }
        public bool IncludeOutliers { get; set; }
        public List<string> Categories { get; set; }
        public bool NormalizeData { get; set; }
    }
}
