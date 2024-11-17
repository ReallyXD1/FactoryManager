using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Quality
{
    public class QualityReportOptions
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<string> ProductIds { get; set; }
        public List<string> Categories { get; set; }
        public bool IncludeNonConformities { get; set; }
        public bool IncludeCharts { get; set; }
        public string ReportFormat { get; set; }
        public List<string> Parameters { get; set; }
        public bool IncludeImages { get; set; }
        public string GroupBy { get; set; }
        public bool IncludeStatistics { get; set; }
        public List<string> CustomFields { get; set; }
    }
}
