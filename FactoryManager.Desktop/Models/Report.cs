using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public DateTime GenerationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string GeneratedBy { get; set; }
        public string Format { get; set; }
        public byte[] Content { get; set; }
        public List<ChartDataPoint> Charts { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
    }
}
