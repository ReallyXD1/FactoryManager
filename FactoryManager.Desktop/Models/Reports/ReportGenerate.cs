using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Reports
{
    public class ReportGenerate
    {
        public int TemplateId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        public string Format { get; set; }
        public List<string> Recipients { get; set; }
        public bool SaveCopy { get; set; }
        public string OutputPath { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
        public List<string> Tags { get; set; }
        public bool IncludeCharts { get; set; }
        public string Language { get; set; }
        public string TimeZone { get; set; }
    }
}
