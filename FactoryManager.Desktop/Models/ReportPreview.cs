namespace FactoryManager.Desktop.Models
{
    public class ReportPreview
    {
        public string Title { get; set; }
        public List<ChartDataPoint> Series { get; set; }
        public Dictionary<string, object> Summary { get; set; }
        public List<string> Warnings { get; set; }
        public bool HasData { get; set; }
    }
}
