using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Reports
{
    public class ReportFormat
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public string MimeType { get; set; }
        public bool SupportsInteractivity { get; set; }
        public List<string> Features { get; set; }
        public Dictionary<string, object> Settings { get; set; }
        public long MaxFileSize { get; set; }
        public bool RequiresLicense { get; set; }
    }
}
