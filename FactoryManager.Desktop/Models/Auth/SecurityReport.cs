using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityReport
    {
        public int Id { get; set; }
        public string ReportType { get; set; }
        public DateTime GeneratedAt { get; set; }
        public string GeneratedBy { get; set; }
        public Dictionary<string, object> Data { get; set; }
        public string Format { get; set; }
        public TimeSpan Period { get; set; }
        public List<string> Recipients { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        public string Status { get; set; }
    }
}
