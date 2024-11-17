using System;

namespace FactoryManager.Desktop.Models.Reports
{
    public class ReportPreview
    {
        public int ReportId { get; set; }
        public byte[] ThumbnailImage { get; set; }
        public string PreviewHtml { get; set; }
        public int PageCount { get; set; }
        public DateTime GeneratedAt { get; set; }
        public long EstimatedSize { get; set; }
        public Dictionary<string, object> Summary { get; set; }
        public List<string> Warnings { get; set; }
        public TimeSpan GenerationTime { get; set; }
    }
}
